import esbuild from 'esbuild';
import ts from 'typescript';
import fs from 'node:fs';
import plugin from 'node-stdlib-browser/helpers/esbuild/plugin';
import stdLibBrowser  from 'node-stdlib-browser';

// build Oolong
esbuild.build({
  entryPoints: ['oolong.js'],
  bundle: true,
  format: 'esm',
  minify: true,
  outfile: '../Runtime/Resources/oolong.js',
});

// build SourceMap
esbuild.build({
  entryPoints: ['./src/source-map.ts'],
  bundle: true,
  format: 'esm',
  inject: ['./node_modules/node-stdlib-browser/helpers/esbuild/shim'],
  define: {
    global: 'global',
    process: 'process',
    Buffer: 'Buffer'
  },
  plugins: [plugin(stdLibBrowser)],
  minify: true,
  platform: 'node',
  outfile: '../Editor/Resources/oolong/source-map.js',
});

const options = {
  skipLibCheck: true,
  declaration: true,
  emitDeclarationOnly: true,
  typeRoots: [
    '../../../Library/PackageCache/com.tencent.puerts.core@2.0.3/Typing',
    '../Generated/Typings~',
  ],
};

const factory = ts.factory;
const declarations = [];
const imports = {};

const collectDeclartion = sourceFile => {
  const visitor = node => {
    if (node.kind == ts.SyntaxKind.SourceFile) {
      node.forEachChild(node => {
        if (node.kind == ts.SyntaxKind.ImportDeclaration) {
          if (!node.moduleSpecifier.text.startsWith('.')) {
            node.moduleSpecifier = factory.createStringLiteral(node.moduleSpecifier.text);
            imports[node.moduleSpecifier.text] = node;
          }
        } else if (node.kind != ts.SyntaxKind.ExportDeclaration) {
          declarations.push(node);
        }
      });
    }
  };
  return ts.visitNode(sourceFile, visitor);
};

const host = ts.createCompilerHost(options);
host.writeFile = (fileName, text, _, __, sourceFiles) => {
  for (const sourceFile of sourceFiles) {
    collectDeclartion(sourceFile);
  }
};
const program = ts.createProgram(['./src/oolong.ts'], options, host);

var result = program.emit();
console.log(result.diagnostics);

const declarationFile = factory.createSourceFile(
  [
    /// ...Object.values(imports),
    factory.createExportDeclaration(
      undefined,
      false,
      factory.createNamedExports([]),
      undefined,
      undefined
    ),
    factory.createModuleDeclaration(
      [factory.createToken(ts.SyntaxKind.DeclareKeyword)],
      factory.createIdentifier('global'),
      factory.createModuleBlock(declarations),
      ts.NodeFlags.ExportContext |
        ts.NodeFlags.GlobalAugmentation |
        ts.ModifierFlags.Ambient |
        ts.NodeFlags.ContextFlags
    ),
  ],
  factory.createToken(ts.SyntaxKind.EndOfFileToken),
  ts.NodeFlags.None
);

const header = `/// <reference types="csharp-oolong"/>\n`;
const printer = ts.createPrinter({ newLine: ts.NewLineKind.LineFeed });
const file = `${header}${printer.printFile(declarationFile)}`;
fs.mkdirSync('../Typings~/oolong', { recursive: true });
fs.writeFileSync('../Typings~/oolong/index.d.ts', file);

// build tsconfig-gen
esbuild.build({
  entryPoints: ['./src/tsconfig-patch.ts'],
  bundle: true,
  format: 'esm',
  minify: true,
  outfile: '../Editor/Resources/oolong/tsconfig-patch.js',
});
