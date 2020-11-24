import * as React from "react";
import { getTasks, Task } from "./services/Api";

interface AppState {
    tasks: Task[];
}

export class App extends React.Component<{}, AppState> {

    constructor(props: {}) {
        super(props);
        this.state = { tasks: [] };
    }

    componentDidMount() {
        getTasks().then(data => {
            console.log("data are comming: ", data);
            this.setState({ tasks: data });
        });        
    }

    render() {
        console.log("render", this.state.tasks.length);
        return <div>
            ITEMS:
            {this.state.tasks.map((i, idx) => 
                <div key={idx}>{i.name}</div>
            )}
        </div>;
    }
}