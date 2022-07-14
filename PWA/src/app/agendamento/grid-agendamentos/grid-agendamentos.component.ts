import { Component, Input, OnChanges, OnInit, SimpleChanges } from '@angular/core';
import { Clientes } from '../model/Clientes';

@Component({
  selector: 'app-grid-agendamentos',
  templateUrl: './grid-agendamentos.component.html',
  styleUrls: ['./grid-agendamentos.component.css']
})
export class GridAgendamentosComponent implements OnInit, OnChanges {

  @Input() lstAgendamento: Clientes[] = [];

  constructor() { }

  ngOnChanges(changes: SimpleChanges): void {

  }

  ngOnInit(): void {
  }

  deleteItem(index) {
    this.lstAgendamento.splice(index, 1);
    return false;
  }

}
