const apiUrl = (window as any).apiUrl;

export enum TaskStatus {
    NotStarted = 0,
    InProgress = 1,
    Completed = 2
}
export interface Task {
    id: string;
    name: string;
    status: TaskStatus;
}

export async function getTasks(): Promise<Task[]> {
    return (await fetch(`${apiUrl}/tasks`)).json();
}

export async function createTask(item: Partial<Task>): Promise<Task> {
    const response = await fetch(`${apiUrl}/tasks`, { 
        method: "POST", 
        body: JSON.stringify(item),
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return await response.json();
}

export async function updateTask(item: Task): Promise<boolean> {
    const response = await fetch(`${apiUrl}/tasks/${encodeURIComponent(item.id)}`, { 
        method: "PUT", 
        body: JSON.stringify(item),
        headers: {
            'Content-Type': 'application/json'
        },
    });

    return response.status === 200;
}

export async function deleteTask(id: string): Promise<boolean> {
    const response = await fetch(`${apiUrl}/tasks/${encodeURIComponent(id)}`, { 
        method: "DELETE", 
    });

    return response.status === 200;
}