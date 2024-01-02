export default class Menu extends MithrilComponent {
    view() {
        return (
            <button
                src="#"
                color="#000055"
                align="stretch"
                onclick={() => {
                    m.route.set("/");
                }}
            >
                <button
                    transition-property="rect"
                    transition-duration="1s"
                    margin={40}
                    margin-right={100}
                    src="#"
                    color="#AA0000"
                ></button>
            </button>
        );
    }
}
