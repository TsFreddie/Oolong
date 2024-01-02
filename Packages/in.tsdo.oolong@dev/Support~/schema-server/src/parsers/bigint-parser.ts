import ts from 'typescript';

import { Context, BaseType, SubNodeParser } from '../ts-json-schema-generator';
import { BigIntType } from '../types/bigint-type';

export class BigIntParser implements SubNodeParser {
  supportsNode(node: ts.Node): boolean {
    if (node.kind === ts.SyntaxKind.BigIntKeyword) return true;
    return false;
  }

  createType(_node: ts.Node, _context: Context): BaseType | undefined {
    return new BigIntType();
  }
}
