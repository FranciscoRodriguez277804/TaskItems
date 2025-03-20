import { Component, inject, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatTableModule } from '@angular/material/table'; // Importar MatTableModule

import { TaskService } from '../../services/task.service';

@Component({
  selector: 'app-task-list',
  standalone: true,
  imports: [CommonModule, MatTableModule], // Agregar MatTableModule a los imports
  templateUrl: './task-list.component.html',
  styleUrls: ['./task-list.component.css'],
})
export class TaskListComponent implements OnInit {
  tasks: any[] = [];
  displayedColumns: string[] = ['id', 'title', 'completed']; // Columnas que se mostrarán en la tabla
  private taskService = inject(TaskService);

  ngOnInit(): void {
    this.taskService.getTasks().subscribe((data) => {
      this.tasks = data;
    });
  }
}