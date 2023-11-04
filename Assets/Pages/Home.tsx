export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="none"
                z="30"
                color="#ff0000"
                align="stretch"
                onclick={() => {
                    m.route.set("/menu");
                }}
            ></button>
        );
    }
}
