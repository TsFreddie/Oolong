import "reflect-metadata";

(editor: )
const globalExtension: any = globalThis;

globalExtension.Inspect = (name: string, type: { new(): any }) => (target: any, propertyKey: string) => {

}
