import { Component, NgModule, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from "../../material-module";
import { StatisticsService } from "../../shared/services/statistics.service";

@Component({
  selector: 'statistics-popup',
  templateUrl: './statistics-popup.component.html',
  styleUrls: ['./statistics-popup.component.css'],
})
export class StatisticsPopupComponent {
  displayedColumns: string[] = ['name', 'games', 'wins', 'top5', 'kills'];
  dataSource: any[] = [
    { name: 'skY', stats: { id: 1, games: 10, wins: 10, top5: 10, kills: 100 } },
    { name: 'Provodnik17', stats: { games: 10, wins: 10, top5: 10, kills: 98 } },
    { name: 'Dowakin', stats: { games: 10, wins: 10, top5: 10, kills: 73 } },
    { name: 'Gridiron', stats: { games: 10, wins: 10, top5: 10, kills: 61 } },
    { name: 'Proterian', stats: { games: 10, wins: 10, top5: 10, kills: 53 } },
    { name: 'AAAA', stats: { games: 10, wins: 9, top5: 9, kills: 43 } },
    { name: 'BBBBB', stats: { games: 10, wins: 9, top5: 9, kills: 57 } },
    { name: 'Oxygen', stats: { games: 10, wins: 9, top5: 9, kills: 60 } },
    { name: 'sty', stats: { games: 10, wins: 9, top5: 9, kills: 40 } },
    { name: 'Neon', stats: { games: 10, wins: 6, top5: 9, kills: 12 } }
  ];

  constructor(private statistics: StatisticsService,
    public dialogRef: MatDialogRef<StatisticsPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    this.statistics.getStatistics("?_order_by=wins+desc,kills+desc").subscribe(result => {
      this.dataSource = result;
    });
  }


  cancel(): void {
    this.dialogRef.close();
  }
}

@NgModule({
  declarations: [StatisticsPopupComponent],
  exports: [StatisticsPopupComponent],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    DragDropModule,
    NgbModule,
    MatButtonModule,
    MaterialModule,
  ]
})
export class StatisticsPopupModule { }
