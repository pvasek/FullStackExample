import { createTask, deleteTask, getTasks, Task, TaskStatus, updateTask } from "./services/Api";
import { action, computed, makeObservable, observable } from "mobx";

export class AppModel {
    
    constructor() {
        makeObservable(this, {
            items: observable,
            newItemName: observable,
            addTask: action.bound,
            setTaskName: action,
            isInvalid: computed,
        });
    }

    items: Task[] = [];
    newItemName: string = "";
    get isInvalid(): boolean {
        return this.items.some(i => i.name === this.newItemName);
    }

    async load() {
        this.items = await getTasks();
    }

    setTaskName(name: string) {
        this.newItemName = name;
    }

    async addTask() {
        const item = await createTask({ 
            id: "00000000-0000-0000-0000-000000000000",
            name: this.newItemName,
            status: TaskStatus.NotStarted,
        });
        this.items.push(item);
        this.newItemName = "";
    }

    async deleteTask(item: Task) {
        if (await deleteTask(item.id)) {
            const idx = this.items.indexOf(item);
            this.items.splice(idx, 1);
        }
    }

    async updateTask(item: Task, status: TaskStatus) {
        if (await updateTask({ ...item, status })) {
            item.status = status;
        }
    }
}
