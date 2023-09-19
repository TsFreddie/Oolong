import m from 'mithril';
import { MithrilComponent } from './mithril.js';

export abstract class Realtime extends MithrilComponent {
  private interval: number;
  oncreate(vnode: m.VnodeDOM<{}, this>) {
    var dom = vnode.dom;
    var self = this;
    this.interval = setInterval(() => {
      m.render(dom, self.onvalueupdate());
    }, 0);
  }

  abstract onvalueupdate(): m.Children;

  view(vnode: m.Vnode<{}, this>): void | m.Children {
    return m('panel');
  }

  onbeforeremove(vnode: m.VnodeDOM<{}, this>): void | Promise<any> {
    clearInterval(this.interval);
  }
}

export class RealtimeText extends Realtime {
  override onvalueupdate(): m.Children {
    return m('text', Math.random().toString());
  }
}
