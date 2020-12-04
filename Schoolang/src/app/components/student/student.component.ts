import { Student } from './../../models/Student';
import { StudentService } from './../../service/student.service';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-alunos',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {

  public modalRef: BsModalRef;
  public studentForm: FormGroup;
  public tittle = 'Alunos';
  public studentSelected: Student;
  public textSimple: string;

  public students: Student[];


  constructor(private fb: FormBuilder,
              private modalService: BsModalService,
              private studentService: StudentService) {
    this.createForm();
   }


  ngOnInit(): void {
    this.loadStudents();
  }

  loadStudents(): void {
    this.studentService.getAll().subscribe(
      (student: Student[]) => {
        this.students = student;
      },
      (err: any) => {
        console.error(err);
      }
    );
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  createForm(): void{
    this.studentForm = this.fb.group({
      name: ['', Validators.required],
      surname: ['', Validators.required],
      cellphone: ['', Validators.required]
    });
  }

  studentSubmit(): void {
    console.info(this.studentForm.value);
  }

  studentSelect(student: Student): void {
    this.studentSelected = student;
    this.studentForm.patchValue(student);
  }

  markOffStudent(): void{
    this.studentSelected = null;
  }
}
