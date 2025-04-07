import { Component, OnInit } from '@angular/core';
import { SubjectService, Subject } from '../subject.service';
import { CommonModule } from '@angular/common';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { NgbAlertModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { StudentService } from '../student.service';

@Component({
  selector: 'app-subject-list',
  standalone: true,
  imports: [CommonModule, HttpClientModule, NgbAlertModule, NgbModule],
  templateUrl: './subject-list.component.html',
  styleUrls: ['./subject-list.component.css']
})
export class SubjectListComponent implements OnInit {
  subjects: Subject[] = [];
  errorMessage: string = '';
  successMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private subjectService: SubjectService,
    private http: HttpClient,
    private studentService: StudentService
  ) {}

  ngOnInit(): void {
    this.loadSubjects();
  }

  loadSubjects(): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';
    
    this.subjectService.getStudentSubjects().subscribe({
      next: (response) => {
        this.subjects = response.data;
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = 'Error al cargar las materias. Por favor intenta nuevamente.';
        this.isLoading = false;
        console.error('Error loading subjects:', error);
      }
    });
  }

  assignSubject(subjectCode: string): void {
    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    this.subjectService.assignSubject(subjectCode).subscribe({
      next: (response) => {
        if (response.statusCode === 200) {
          this.successMessage = response.message;
          // Recargar la lista después de asignar
          this.loadSubjects();
        } else {
          this.errorMessage = response.message || 'Error al asignar la materia';
        }
        this.isLoading = false;
      },
      error: (error) => {
        this.errorMessage = error.error?.message || 'Error al asignar la materia';
        this.isLoading = false;
      }
    });
  }
}