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
  public mode = 'post';

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

  registerStudent(): void{
    this.studentSelected = new Student();
    this.studentForm.patchValue(this.studentSelected);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  createForm(): void{
    this.studentForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      cellphone: ['', Validators.required]
    });
  }

  saveStudent(student: Student): void {
    (student.id === 0) ? this.mode = 'post' : this.mode = 'put'

    this.studentService[this.mode](student).subscribe(
      (student: Student) => {
        // console.log(student);
        this.loadStudents();
      },
      (error: any) => {
        console.log(error)
      }
    );
  }

  deleteStudent(id: number){
      this.studentService.delete(id).subscribe(
        (model: any) => {
          console.log(`Deletado com suceso -> ${model}`)
          this.loadStudents();
        },
        (error: any) => {
          console.error(`Error ${error}`);
        }
      );
  }

  studentSubmit(): void {
    this.saveStudent(this.studentForm.value);
  }

  studentSelect(student: Student): void {
    this.studentSelected = student;
    this.studentForm.patchValue(student);
  }

  markOffStudent(): void{
    this.studentSelected = null;
  }
}
