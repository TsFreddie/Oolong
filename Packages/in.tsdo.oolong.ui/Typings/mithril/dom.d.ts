export {}

declare global {
    export interface HistoryEntry {
        state: string;
        title: string;
        url?: string;
    }

    export class UnityElement extends HTMLElement {
        public element: CS.TSF.Oolong.UI.IOolongElement;

        constructor(element: CS.TSF.Oolong.UI.IOolongElement);
        constructor(tagName: string);
    }

    export class UnityFragment extends DocumentFragment {
    }

    export class UnityDocument {
        createDocumentFragment(): UnityFragment;

        createElement(tagName: string): UnityElement;
    }

    export class UnityLocation {
        hash: string;
        href: string;
    }

    export class UnityHistory {
        private historyStack;

        pushState(state: string, title: string, url?: string): void;

        replaceState(state: string, title: string, url?: string): void;
    }

    export class UnityWindow {
        private animationFrameQueue;
        location: UnityLocation;
        history: UnityHistory;
        document: UnityDocument;

        requestAnimationFrame(cb: () => void): void;

        addEventListener(event: string, cb: (e: any) => void): void;

        tick(): void;
    }
}
