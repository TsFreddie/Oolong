// Utilities to help with Unity specific features

import ts from 'typescript';
import { isPublic } from './modifiers';
import { hasDecorator } from './decorators';

export function isUnitySerializable(
  node: ts.PropertyDeclaration | ts.PropertySignature | ts.ParameterPropertyDeclaration
): boolean {
  if (node.kind === ts.SyntaxKind.PropertySignature) {
    return isPublic(node);
  }

  return (
    (isPublic(node) && !hasDecorator(node, 'NonSerialized')) || hasDecorator(node, 'SerializeField')
  );
}
