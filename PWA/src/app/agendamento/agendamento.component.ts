import { Component, OnInit, ViewChild } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { ReservationService } from 'src/service/agendamento.service';
import Swal from 'sweetalert2';
import { ReservationRequest } from './model/Reservation';
import { GridAgendamentosComponent } from './grid-agendamentos/grid-agendamentos.component';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {
  @ViewChild(GridAgendamentosComponent) childGrid: GridAgendamentosComponent;
  idUpdate;
  isUpdate:boolean = false;
  agendamentoForm: FormGroup;
  lstAgendamentos: ReservationRequest[] = [];


  constructor(private fb: FormBuilder, private reservation: ReservationService) {

  }

  ngOnInit(): void {
    this.criarForm();
  }
  criarForm() {
    this.agendamentoForm = this.fb.group({
      txtNomeCliente: ['', Validators.required],
      start: ['', Validators.required],
      end: ['', Validators.required]
    })

  }
  addItem(newItem) {
    if(newItem != null)
    {
      this.agendamentoForm.get('txtNomeCliente').setValue(newItem.name);
      this.agendamentoForm.get('start').setValue(newItem.beginDate);
      this.agendamentoForm.get('end').setValue(newItem.endDate);
      this.idUpdate = newItem.id;
      this.isUpdate = true;
    }
  }
  updateItem() : void
  {
    let beginData = new Date(this.agendamentoForm.get('start').value);
    let endDate = new Date(this.agendamentoForm.get('end').value);

    const reservation: ReservationRequest =
    {
      Name: this.agendamentoForm.get('txtNomeCliente').value,
      BeginDate: beginData,
      EndDate: endDate,
      Id: this.idUpdate
    };
    this.reservation.update(reservation).subscribe((result) =>{
      if (result.error === 1) { 
        
        Swal.fire({
          icon: 'error',
          title: result.msg,
          showConfirmButton: true
        })
      }
      else{
        Swal.fire({
          icon: 'success',
          title: result.msg,
          showConfirmButton: true
        }).then((result) => {
          this.childGrid.loadReservations();
          
        })
        
      }
    })
    this.isUpdate=false;
  }
  agendaSubmit() {

    let beginData = new Date(this.agendamentoForm.get('start').value);
    let endDate = new Date(this.agendamentoForm.get('end').value);

    const reservation: ReservationRequest =
    {
      Name: this.agendamentoForm.get('txtNomeCliente').value,
      BeginDate: beginData,
      EndDate: endDate
    };

    this.reservation.insert(reservation).subscribe((result) => {
      if (result.msg != "") { 
        
        Swal.fire({
          icon: 'error',
          title: result.msg,
          showConfirmButton: true
        })
      }
      else{
        Swal.fire({
          icon: 'success',
          title: "Reservation complete!",
          showConfirmButton: true
        }).then((result)=>{
          this.childGrid.loadReservations();
        })
      }
    })

    this.agendamentoForm.get('txtNomeCliente').setValue('');
    this.agendamentoForm.get('start').setValue('');
    this.agendamentoForm.get('end').setValue('');
    this.agendamentoForm.setErrors(null);
    this.childGrid.loadReservations();
  }
}
