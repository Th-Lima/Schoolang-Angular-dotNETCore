import { Teacher } from './../../models/Teacher';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { TeacherService } from 'src/app/service/teacher.service';

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

  public teachers: Teacher[];

  constructor(private modalService: BsModalService, private teacherService: TeacherService, private fb: FormBuilder)
  {
    this.createForm();
  }

  ngOnInit() {
    this.loadTeacher();
  }

  createForm(): void{
    this.teacherForm = this.fb.group({
      id: [''],
      name: ['', Validators.required],
    });
  }

  saveTeacher(teacher: Teacher): void {
    this.teacherService.put(teacher.id, teacher).subscribe(
      (teacher: Teacher) => {
        // console.log(student);
        this.loadTeacher();
      },
      (error: any) => {
        console.log(error)
      }
    );
  }


  teacherSubmit(): void{
    this.saveTeacher(this.teacherForm.value);
  }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template);
  }

  teacherSelect(teacher: Teacher): void{
    this.teacherSelected = teacher;
    this.teacherForm.patchValue(teacher);
  }

  marOffTeacher(): void{
    this.teacherSelected = null;
  }

  loadTeacher(): void {
    this.teacherService.getAll().subscribe(
      (teacher: Teacher[]) => {
        this.teachers = teacher;
      },
      (error: any) => {
        console.error(error);
      }
    );
  }
}
