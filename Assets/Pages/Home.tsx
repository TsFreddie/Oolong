export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="#"
                color="#550000"
                align="stretch"
                onclick={() => {
                    m.route.set("/menu");
                }}
            ></button>
        );
    }
}
