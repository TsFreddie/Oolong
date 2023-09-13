import { BaseType, Definition, FunctionType, SubTypeFormatter } from '../ts-json-schema-generator';

export class FunctionFormatter implements SubTypeFormatter {
  public supportsType(type: FunctionType): boolean {
    return type instanceof FunctionType;
  }
  public getDefinition(_type: FunctionType): Definition {
    return { type: 'object' };
  }
  public getChildren(_type: FunctionType): BaseType[] {
    return [];
  }
}
