import sourceMapSupport from 'source-map-support';

const OolongEditor: any = (CS as any).TSF.Oolong.Editor;

sourceMapSupport.install({
  handleUncaughtExceptions: false,
  environment: 'node',
  retrieveSourceMap(file) {
    let map = OolongEditor.SourceMap.Map(file);
    if (map) {
      return {
        url: map,
        map: OolongEditor.SourceMap.Read(map),
      };
    }
    return null;
  },
});
