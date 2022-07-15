import { Component, Input, OnChanges, OnInit, Output, SimpleChanges,EventEmitter } from '@angular/core';
import { ReservationService } from 'src/service/agendamento.service';
import Swal from 'sweetalert2';


@Component({
  selector: 'app-grid-agendamentos',
  templateUrl: './grid-agendamentos.component.html',
  styleUrls: ['./grid-agendamentos.component.css']
})
export class GridAgendamentosComponent implements OnInit {

  lstAgendamento;
  @Output() newItemEvent = new EventEmitter<string>();
  constructor(private reservation: ReservationService) { 

  }
  addNewItem(value) {
    this.newItemEvent.emit(value);
  }
  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnInit(): void {
    this.loadReservations();
  }
  loadReservations() {
    this.reservation.select().subscribe((result) => {
      if (result != null)
        this.lstAgendamento = result;
    })
  }
 
  deleteItem(index) {
    this.reservation.cancel(index).subscribe((result) => {
      Swal.fire({
        icon: 'success',
        title: 'Rervation cancel successfully!',
        showConfirmButton: true
      }).then((result)=>{
    this.loadReservations();
      
    })

    })
  }
}
