import { BaseType } from './BaseType';

export type BigIntValue = { type: 'bigint'; value: string };
export type LiteralValue = string | number | boolean | BigIntValue;

export class LiteralType extends BaseType {
  public constructor(private value: LiteralValue) {
    super();
  }

  public getId(): string {
    return JSON.stringify(this.value);
  }

  public getValue(): LiteralValue {
    return this.value;
  }
}
