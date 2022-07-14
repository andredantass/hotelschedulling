import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';
import { Clientes } from './model/Clientes';
import { SchedullingService } from '../../services/schedulling.service'; 
import { SharedDataService } from 'src/app.commons/SharedDataService.service';

@Component({
  selector: 'app-agendamento',
  templateUrl: './agendamento.component.html',
  styleUrls: ['./agendamento.component.css']
})
export class AgendamentoComponent implements OnInit {
  agendamentoForm: FormGroup;
  lstAgendamentos: Clientes[] = [];


  constructor(private fb : FormBuilder, private schedullingService:SchedullingService, private sharedDataService : SharedDataService) {
    this.criarForm();
  }

  ngOnInit(): void {
      
  }
  criarForm(){
    this.agendamentoForm = this.fb.group({
      Name: ['',Validators.required],
      BeginDate: ['', Validators.required],
      EndDate: ['', Validators.required]
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
        this.loadSchedule();
        this.lstAgendamentos.push(this.agendamentoForm.value);
        this.agendamentoForm.get('Name').setValue('');
        this.agendamentoForm.get('BeginDate').setValue('');
        this.agendamentoForm.get('EndDate').setValue('');
    })
  }

  loadSchedule(): void {
    const ScheduleModel: Clientes =
    {
      Name: this.agendamentoForm.get('Name').value,
      BeginDate: this.agendamentoForm.get('BeginDate').value,
      EndDate: this.agendamentoForm.get('EndDate').value
    };


  

    this.schedullingService.setSchedule(ScheduleModel)
      .subscribe((result) => {
        if (result.data.length > 0) {
          this.sharedDataService.passCustomerPolicyData(result.data);
        }
      });

  }

  
  

}
