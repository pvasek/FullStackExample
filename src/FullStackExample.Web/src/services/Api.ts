const apiUrl = (window as any).apiUrl;

export interface Task {
    name: string;
}

export async function getTasks(): Promise<Task[]> {
    return (await fetch(`${apiUrl}/tasks`)).json();
}