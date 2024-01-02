import { BaseType, Definition, SubTypeFormatter } from '../ts-json-schema-generator';
import { BigIntType } from '../types/bigint-type';

export class BigIntFormatter implements SubTypeFormatter {
  public supportsType(type: BigIntType): boolean {
    return type instanceof BigIntType;
  }
  public getDefinition(_type: BigIntType): Definition {
    return {
      type: 'object',
      properties: {
        type: {
          type: 'string',
          const: 'bigint',
        },
        value: {
          type: 'string',
        },
      },
      required: ['type', 'value'],
      additionalProperties: false,
    };
  }
  public getChildren(_type: BigIntType): BaseType[] {
    return [];
  }
}
