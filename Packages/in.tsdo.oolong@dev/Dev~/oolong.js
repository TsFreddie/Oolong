import * as oolong from './src/oolong';

const global = {
  ...oolong,
};

for (var k in global) {
  globalThis[k] = global[k];
}
