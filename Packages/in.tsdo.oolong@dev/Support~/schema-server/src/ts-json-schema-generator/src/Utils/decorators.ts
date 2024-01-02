import ts from 'typescript';
import { LiteralValue } from '../..';

/**
 * Checks if given node has the given decorator.
 *
 * @param node     - The node to check.
 * @param decoratorName - The decorator to look for.
 * @return True if node has the decorator, false if not.
 */
export function hasDecorator(
  node: ts.PropertyDeclaration | ts.ParameterPropertyDeclaration,
  decoratorName: string
): boolean {
  return ts.getDecorators(node)?.some(decorator => {
    var decoratorToken = decorator.getChildAt(1);
    if (decoratorToken.getChildCount() == 0) {
      return false;
    }
    return decoratorToken.getFirstToken().getText() === decoratorName;
  });
}

/**
 * Gets the nodes for a given decorator name.
 *
 * @param node - The node to check.
 * @param decoratorName - The decorator to look for.
 * @return The nodes of the decorator if found, undefined if not.
 */
export function getDecoratorsOf(
  node: ts.PropertyDeclaration | ts.ParameterPropertyDeclaration,
  decoratorName: string
): ts.Decorator[] {
  return ts.getDecorators(node)?.filter(decorator => {
    var decoratorToken = decorator.getChildAt(1);
    if (decoratorToken.getChildCount() == 0) {
      return false;
    }
    return decoratorToken.getFirstToken().getText() === decoratorName;
  });
}
