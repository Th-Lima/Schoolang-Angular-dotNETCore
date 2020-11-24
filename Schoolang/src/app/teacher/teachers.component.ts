import { Teacher } from './../models/Teacher';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-professores',
  templateUrl: './teachers.component.html',
  styleUrls: ['./teachers.component.css']
})
export class TeachersComponent implements OnInit {

  public modalRef: BsModalRef;
  public teacherForm: FormGroup;
  public tittle = 'Professores';
  public teacherSelected: Teacher;

  public teachers = [
    {id: 1, name: 'Lúcia', language: 'Inglês'},
    {id: 2, name: 'Ana',  language: 'Francês'},
    {id: 3, name: 'César', language: 'Italiano'},
  ];

  constructor(private modalService: BsModalService) {}

  ngOnInit() {
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  teacherSelect(teacher: Teacher): void{
    this.teacherSelected = teacher;
  }

  marOffTeacher(): void{
    this.teacherSelected = null;
  }
}
