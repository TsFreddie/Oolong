import { PrimitiveType } from '../ts-json-schema-generator';

export class BigIntType extends PrimitiveType {
  public getId(): string {
    return 'bigint';
  }
}
