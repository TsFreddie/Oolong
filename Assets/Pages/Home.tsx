export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="none"
                color="#ff0000"
                align="stretch"
                onclick={() => {
                    m.route.set("/menu");
                }}
            ></button>
        );
    }
}
