import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { Clientes } from './model/Clientes';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {
  agendamentoForm: FormGroup;
  lstAgendamentos: Clientes[] = [];


  constructor(private fb : FormBuilder) {
    this.criarForm();
  }

  ngOnInit(): void {
      
  }
  criarForm(){
    this.agendamentoForm = this.fb.group({
      txtNomeCliente: ['',Validators.required],
      start: ['', Validators.required],
      end: ['', Validators.required]
    })
    
  }

  agendaSubmit() {
    console.log(this.agendamentoForm.value);
    
    Swal.fire({
      icon: 'success',
      title: 'Agendamento efetuado com sucesso!',
      showConfirmButton: false,
      timer: 1500
    }).then((result)=>{
        this.lstAgendamentos.push(this.agendamentoForm.value);
        console.log(this.lstAgendamentos);
        this.agendamentoForm.get('txtNomeCliente').setValue('');
        this.agendamentoForm.get('start').setValue('');
        this.agendamentoForm.get('end').setValue('');
        this.agendamentoForm.setErrors(null);
      
    })
  }

  
  

}
