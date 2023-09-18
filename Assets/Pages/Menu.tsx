export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="none"
                color="#00ff00"
                align="stretch"
                onclick={() => {
                    m.route.set("/");
                }}
            >
                <RealtimeText></RealtimeText>
            </button>
        );
    }
}
