import set from 'lodash/set.js';

const patch = (base: string, patch: string) => {
  const obj = JSON.parse(base);
  const patchObj = JSON.parse(patch);
  for (const key in patchObj) {
    set(obj, key, patchObj[key]);
  }
  return JSON.stringify(obj, null, 4);
};

export default patch;
