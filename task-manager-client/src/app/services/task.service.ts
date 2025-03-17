import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root' // Hace que el servicio esté disponible en toda la app sin necesidad de importarlo en un módulo
})
export class TaskService {
  private apiUrl = 'https://localhost:5138/api/taskitems'; // URL de la API en .NET Core

  constructor(private http: HttpClient) {}

  // Obtener todas las tareas
  getTasks(): Observable<any[]> {
    return this.http.get<any[]>(this.apiUrl);
  }

  // Agregar una nueva tarea
  addTask(task: any): Observable<any> {
    return this.http.post<any>(this.apiUrl, task);
  }

  // Eliminar una tarea
  deleteTask(id: number): Observable<any> {
    return this.http.delete(`${this.apiUrl}/${id}`);
  }
}
