import { Component, NgModule, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { DragDropModule } from '@angular/cdk/drag-drop';
import { CommonModule } from '@angular/common';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatButtonModule } from '@angular/material/button';
import { MaterialModule } from "../../material-module";
import { NewsService } from "../../shared/services/news.service";

@Component({
  selector: 'news-popup',
  templateUrl: './news-popup.component.html',
  styleUrls: ['./news-popup.component.css'],
})
export class NewsPopupComponent {
  news: any[] = [
    { id: 1, createdAt: new Date("2020-12-16"), title: 'Голосуйте за Stoneshard в Премии Steam!', description: 'Привет, наёмники!\nДо декабрьского патча Equipment Update II осталось совсем немного времени: в ближайшие недели вас ждут несколько девлогов о новом контенте и механиках, которые оно привнесёт в игру.\nА пока над обновлением кипит работа, мы хотели бы попросить вас номинировать нашу игру в категории «Лучшая игра, которая вам не даётся» – хотя бы потому, что это скорей всего действительно так.В конце концов, «игра не для слабонервных, вознаграждающая упорство» отлично описывает Stoneshard – и мы будем крайне признательны, если вы нас в этом поддержите!\nНа этом всё.Оставайтесь на связи: увидимся уже завтра в новом девлоге!', imageLink: 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/28578038/5bc6158c74aa2f7f4d8ac3550fc8b8e61730a83f.png' },
    { id: 2, createdAt: new Date("2020-12-17"), title: 'Девлог: Последние приготовления', description: 'Всем привет!\nВ сегодняшнем девлоге мы подведём итог обновлению Equipment Update II, рассказав о всех оставшихся нововведениях, а также объявим дату его выхода – 25 декабря!', imageLink: 'https://steamcdn-a.akamaihd.net/steamcommunity/public/images/clans/28578038/bd45e6e5d43de0c920b8ff20f32e0102ec3d54b0.png' }
  ];

  constructor(private newsService: NewsService,
    public dialogRef: MatDialogRef<NewsPopupComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any) {
  }

  ngOnInit(): void {
    this.newsService.getNews().subscribe(result => {
      this.news = result;
    });
  }

  cancel(): void {
    this.dialogRef.close();
  }

  getDate(date): string {
    return `${date.getDate()}/${date.getMonth() + 1}/${date.getFullYear()}`;
  }
}

@NgModule({
  declarations: [NewsPopupComponent],
  exports: [NewsPopupComponent],
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
export class NewsPopupModule { }
