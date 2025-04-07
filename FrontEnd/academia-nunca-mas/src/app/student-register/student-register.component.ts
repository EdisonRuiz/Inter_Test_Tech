import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { HttpClient, HttpClientModule } from '@angular/common/http';
import { StudentService } from '../student.service';
import { Router } from '@angular/router';
import { NgbAlertModule } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-student-register',
  
  imports: [CommonModule, FormsModule, ReactiveFormsModule, HttpClientModule, NgbAlertModule],
  templateUrl: './student-register.component.html',
  styleUrls: ['./student-register.component.css'] // Cambiado a .css
})
export class StudentRegisterComponent {
  registerForm: FormGroup;
  errorMessage: string = '';
  successMessage: string = '';
  isLoading: boolean = false;

  constructor(
    private fb: FormBuilder,
    private http: HttpClient,
    private router: Router,
    private studentService: StudentService
  ) {
    this.registerForm = this.fb.group({
      name: ['', [Validators.required, Validators.minLength(3)]],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  onSubmit() {
    if (this.registerForm.invalid) {
      return;
    }

    this.isLoading = true;
    this.errorMessage = '';
    this.successMessage = '';

    const studentData = {
      name: this.registerForm.value.name,
      email: this.registerForm.value.email
    };

    this.http.post('https://localhost:7060/api/Students', studentData)
      .subscribe({
        next: (response: any) => {
          this.successMessage = 'Estudiante registrado exitosamente!';
          this.registerForm.reset();
          this.isLoading = false;
          console.log('Registro exitoso:', response.message);
          if (response.message) { // Asegúrate de que tu API devuelva el ID
            this.studentService.setCurrentUserId(response.message);
          }

          setTimeout(() => {
            this.router.navigate(['/list-subjects']);
          }, 2000);
        },
        error: (error) => {
          this.isLoading = false;
          if (error.status === 400) {
            this.errorMessage = error.error.message || 'El email ya está registrado. Por favor usa otro.';
          } else {
            this.errorMessage = 'Error al registrar el estudiante. Por favor intenta nuevamente.';
          }
        }
      });
  }
}