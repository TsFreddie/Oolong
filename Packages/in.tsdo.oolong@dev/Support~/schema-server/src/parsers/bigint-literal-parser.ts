import ts from 'typescript';

import {
  Context,
  LiteralType,
  BaseType,
  SubNodeParser,
  BigIntValue,
} from '../ts-json-schema-generator';

export class BigIntLiteralParser implements SubNodeParser {
  public supportsNode(node: ts.BigIntLiteral): boolean {
    return node.kind === ts.SyntaxKind.BigIntLiteral;
  }
  public createType(node: ts.BigIntLiteral, context: Context): BaseType {
    var value = node.getText();
    var bigintObject: BigIntValue = {
      type: 'bigint',
      value: value.substring(0, value.length - 1),
    };
    return new LiteralType(bigintObject);
  }
}
