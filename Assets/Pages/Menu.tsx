export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="#"
                color="#005500"
                align="stretch"
                onclick={() => {
                    m.route.set("/");
                }}
            ></button>
        );
    }
}
