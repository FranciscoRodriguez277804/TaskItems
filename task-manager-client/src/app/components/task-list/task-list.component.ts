import { Component, inject, OnInit } from '@angular/core';
import { TaskService } from '../../services/task.service';  // Asegúrate de tener el servicio en la misma carpeta o actualizar la ruta

@Component({
  selector: 'app-task-list',
  standalone: true,  // Definir que es un componente standalone
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
})
export class TaskListComponent implements OnInit {
  tasks: any[] = [];
  private taskService = inject(TaskService);  // Inyección de dependencia en componente standalone

  ngOnInit(): void {
    this.taskService.getTasks().subscribe((data) => {
      this.tasks = data;
    });
  }
}
