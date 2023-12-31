import ts from "typescript";
import { Context, NodeParser } from "../NodeParser";
import { SubNodeParser } from "../SubNodeParser";
import { ArrayType } from "../Type/ArrayType";
import { BaseType } from "../Type/BaseType";
import { NumberType } from "../Type/NumberType";
import { ObjectType } from "../Type/ObjectType";
import { StringType } from "../Type/StringType";
import { UnionType } from "../Type/UnionType";
import { derefType } from "../Utils/derefType";
import { getTypeKeys } from "../Utils/typeKeys";

export class TypeOperatorNodeParser implements SubNodeParser {
    public constructor(protected childNodeParser: NodeParser) {}

    public supportsNode(node: ts.TypeOperatorNode): boolean {
        return node.kind === ts.SyntaxKind.TypeOperator;
    }

    public createType(node: ts.TypeOperatorNode, context: Context): BaseType {
        const type = this.childNodeParser.createType(node.type, context);
        const derefed = derefType(type);
        // Remove readonly modifier from type
        if (node.operator === ts.SyntaxKind.ReadonlyKeyword && derefed) {
            return derefed;
        }
        if (derefed instanceof ArrayType) {
            return new NumberType();
        }
        const keys = getTypeKeys(type);
        if (derefed instanceof ObjectType && derefed.getAdditionalProperties()) {
            return new UnionType([...keys, new StringType()]);
        }

        if (keys.length === 1) {
            return keys[0];
        }

        return new UnionType(keys);
    }
}
