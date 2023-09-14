import {
  BaseType,
  Definition,
  DefinitionType,
  SubTypeFormatter,
} from '../ts-json-schema-generator';

export class UnityObjectFormatter implements SubTypeFormatter {
  public supportsType(type: DefinitionType): boolean {
    return type instanceof DefinitionType && type.getName().startsWith('CS.');
  }
  public getDefinition(_type: DefinitionType): Definition {
    return {
      type: 'object',
      properties: {
        type: {
          type: 'string',
          const: 'reference',
        },
        value: {
          type: 'string',
        },
      },
      required: ['type', 'value'],
      additionalProperties: false,
    };
  }
  public getChildren(_type: DefinitionType): BaseType[] {
    return [];
  }
}
