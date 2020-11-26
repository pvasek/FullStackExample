import * as React from "react";
import { observer } from "mobx-react";
import { AppModel } from "./AppModel";
import { Task, TaskStatus } from "./services/Api";


export interface AppProps {
    model: AppModel;
}

@observer
export class App extends React.Component<AppProps> {
    
    constructor(props: AppProps) {
        super(props);
    }
    

    componentDidMount() {
        this.props.model.load();
    }

    render() {
        const { model } = this.props;
        return <div>
            <h1>TASKS</h1>
            <div>
                <input 
                    className={model.isInvalid ? "invalid": ""}
                    type="text"
                    value={model.newItemName}
                    onChange={e => model.setTaskName(e.target.value)}
                />
                <button onClick={model.addTask} disabled={model.isInvalid}>Add</button>
            </div>
            {model.items.map((i, idx) => 
                <div key={idx} className="list">
                    <label>{i.name}</label>
                    <StatusButton item={i} model={model} status={TaskStatus.NotStarted} title="Not Started" />
                    <StatusButton item={i} model={model} status={TaskStatus.InProgress} title="In Progress" />
                    <StatusButton item={i} model={model} status={TaskStatus.Completed} title="Completed" />

                    <button onClick={e => model.deleteTask(i)}>Delete</button>
                </div>
            )}
        </div>;
    }
}

const StatusButton = observer(({status, model, item, title }: { status: TaskStatus, model: AppModel, item: Task, title: string}) => {
    return <button className={item.status === status ? "active" : ""} onClick={e => model.updateTask(item, status)}>{title}</button>
});