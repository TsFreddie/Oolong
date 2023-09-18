import esbuild from "esbuild";
import ts from "typescript";
import fs from "node:fs";

// build DOM
esbuild.build({
    entryPoints: ["dom.js"],
    bundle: true,
    format: "esm",
    minify: true,
    outfile: "../Runtime/Resources/dom.js",
});

// build Mithril
esbuild.build({
    entryPoints: ["mithril.js"],
    bundle: true,
    format: "esm",
    minify: true,
    outfile: "../Runtime/Resources/mithril.js",
});

const options = {
    skipLibCheck: true,
    declaration: true,
    emitDeclarationOnly: true,
    typeRoots: [
        "../../../Library/PackageCache/com.tencent.puerts.core@2.0.2/Typing",
        "../../../Assets/Generated/Puerts/Typing",
        "../../../Packages/in.tsdo.oolong/Typings",
    ],
};

const factory = ts.factory;
const declarations = [];
const imports = {};

const collectDeclartion = (sourceFile) => {
    const visitor = (node) => {
        if (node.kind == ts.SyntaxKind.SourceFile) {
            node.forEachChild((node) => {
                if (node.kind == ts.SyntaxKind.ImportDeclaration) {
                    if (!node.moduleSpecifier.text.startsWith(".")) {
                        node.moduleSpecifier = factory.createStringLiteral(
                            node.moduleSpecifier.text
                        );
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
const program = ts.createProgram(
    ["./src/dom.ts", "./src/mithril.ts", "./src/realtime.ts"],
    options,
    host
);

program.emit();

const declarationFile = factory.createSourceFile(
    [
        ...Object.values(imports),
        factory.createExportDeclaration(
            undefined,
            false,
            factory.createNamedExports([]),
            undefined,
            undefined
        ),
        factory.createModuleDeclaration(
            [factory.createToken(ts.SyntaxKind.DeclareKeyword)],
            factory.createIdentifier("global"),
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

const printer = ts.createPrinter({ newLine: ts.NewLineKind.LineFeed });
const file = printer.printFile(declarationFile);
fs.mkdirSync("../Runtime/Typings~/oolong-ui", { recursive: true });
fs.writeFileSync("../Runtime/Typings~/oolong-ui/index.d.ts", file);
