import fs from 'fs';
import {
  Config,
  SchemaGenerator,
  createFormatter,
  createParser,
  createProgram,
} from './ts-json-schema-generator';
import { BigIntParser } from './parsers/bigint-parser';
import { BigIntFormatter } from './formatters/bigint-formatter';
import { FunctionFormatter } from './formatters/function-formatter';
import { BigIntLiteralParser } from './parsers/bigint-literal-parser';
import { UnityObjectFormatter } from './formatters/unity-object-formatter';

const config: Config = {
  path: 'D:/Projects/OolongUI/Assets/TestBehaviour.ts',
  tsconfig: 'D:/Projects/OolongUI/Assets/tsconfig.json',
  type: '*',
  expose: 'export',
  additionalProperties: false,
  topRef: false,
  skipTypeCheck: true,
  strictTuples: true,
};

const program = createProgram(config);
const parser = createParser(program, config, parsers => {
  parsers.addNodeParser(new BigIntParser());
  parsers.addNodeParser(new BigIntLiteralParser());
});
const formatter = createFormatter(config, formatters => {
  formatters.addTypeFormatter(new UnityObjectFormatter());
  formatters.addTypeFormatter(new BigIntFormatter());
  formatters.addTypeFormatter(new FunctionFormatter());
});
const generator = new SchemaGenerator(program, parser, formatter);
const schema = generator.createSchema(config.type);

const schemaString = JSON.stringify(schema, null, 2);
fs.writeFile('test.json', schemaString, err => {
  if (err) throw err;
});
