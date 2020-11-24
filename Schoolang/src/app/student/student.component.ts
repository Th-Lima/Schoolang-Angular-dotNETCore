import { Student } from './../models/Student';
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

  public students = [
    {id: 1, name: 'Marta', surname: 'Lima', cellphone: 3327841},
    {id: 2, name: 'Luis', surname: 'Souza', cellphone: 354655},
    {id: 3, name: 'João', surname: 'Silva', cellphone: 332255},
    {id: 4, name: 'Júlia', surname: 'Marques', cellphone: 3300225},
    {id: 5, name: 'Thales', surname: 'Araújo', cellphone: 33035105},
    {id: 6, name: 'Paula', surname: 'Monteiro', cellphone: 34850020}
  ];


  constructor(private fb: FormBuilder, private modalService: BsModalService) {
    this.createForm();
   }


  ngOnInit(): void {
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
