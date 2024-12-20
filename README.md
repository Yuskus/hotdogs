### Hotdogs by Yuskus ###  

Это приложение вдохновлено другим, в которое я рубилась как безумная во времена браузерных флеш-игр, мне было тогда лет примерно 15. 
Не так давно, а именно, года 3 назад, я стала искать его версию на смартфон. Конечно, аналогов наплодилось много, но меня интересовала исключительно та версия. 
Она была на телефон, но крайне плохо работала. Спустя время, когда я стала изучать программирование, я решила, что нужно делать какие-нибудь приложения для тренировки и всё началось с калькулятора зарплаты, а далее - этих самых хотдогов. 
То и другое - на Unity, так как там проще создавать интерфейс. Создание игры длилось где-то год (2022 - 2023). Так долго - потому что все фишки, которые я узнавала про C#, испытывала на этом приложении. Поэтому оно тысячи раз писано-переписано. 
И по сему - не могу сказать, что сильно горжусь структурой, однако вот оно. Со временем отрисовала человечков, кнопочки, фоны, продукты, и сейчас это выглядит неплохо. 
Потихоньку играю на досуге и правлю, если нахожу баги. Хочется сделать его в будущем чуть более отзывчивым. 

#### Из интересного:    

1) Бургеры, хот доги, картошка, люди - собираются послойно. Бургер или хот дог состоит спрайта бургера и слоёв добавок.
Человечек состоит из тела, лица, футболки и причёски. Они отрисованы, закинуты в массивы и рандомно собираются с учётом пола муж/унисекс/жен. Там в массиве с одной стороны один пол, с другой - другой, и выбирается равнодушный индекс, но с определённым диапазоном. 
Благодаря этому я старалась избежать слишком странных комбинаций одежда/причёска, и в целом рисовала всё очень универсальное.
Ещё у меня были заготовки слоя с морщинами, чтобы были бабушки и дедушки, но я решила, что грузить простую игру этим не стоит.
Плюс, тогда всё не поместилось бы на один спрайт-атлас (все люди).
2) Касательно атласов - у меня есть стол и еда на одном атласе, люди на втором и отдельно фон.
Также я подбирала шрифты, шейдеры и фон для UI так, чтобы это заняло минимум вызовов отрисовки (UI рисуется за один, всё остальное, кажется, за три).
3) Всё происходит на одной сцене. В зависимости от сохраненных данных (с помощью рефлексии, кстати) добавляется тот или иной скрипт, определяющий логику уровня.
4) Раньше все результаты колхозно хранились в префсах (Prefs), но я переделала это на обычное сохранение в файл. Кстати, из-за объекта, который сохранялся между сценами, он дублироваться при каждой смене сцены. Не сразу поняла, почему еда на уровнях глючит и активируется не вся, а частично. Уровень загружался правильно лишь со второго раза. Оказалось, проблема в DontDestroyOnLoad. Вот тебе и паттерн синглтон... 
5) Анимация собаки, ног собаки, мигающих глаз, огня и дыма покадрово (6 кадров огня), как и вообще всё в этом приложении, было нарисовано мной (в Paint.NET если интересно, простой, но удобный.. и бесплатный). 
6) Музыку написала я. Она циклична и у неё даже есть кульминация. Звуки людей и еды тоже находила и нарезала я. Особенно сложно пришлось со звуком картошки фри, падающей во фритюр - пришлось пересмотреть кучу видео с готовкой картошки фри, чтобы найти тот звук, что я хотела. 
7) Кстати, такса горит, потому что забегалась на работе. 
8) Если пройти все уровни, в главном меню появляется кнопка "потушить собаку". эта идея появилась, когда подруга сказала мне, что ей очень жалко эту таксу. 
9) В главных тестерах вписан Дмитрий Ушаков. Это мой брат. Настолько криворукий, что находит все баги на раз-два. Спасибо, Димон. Не теряй навыки. 
10) Для того, чтобы камера и UI подстроились под соотношение сторон, создала свой скрипт FocusCamera. Должен работать на всех возможных соотношениях. 

### Скрины ###

#### 1. Меню #### 
![image](https://sun9-32.userapi.com/impg/39m0Z9im3EiovD_7cj6SmlliV6XgWABtTYUfqg/C-EFv4bDVcg.jpg?size=2388x1080&quality=95&sign=18e6751f2f9fb5ada3974b3738527198&type=album)  

#### 2. Уровни  
![image](https://sun9-18.userapi.com/impg/OWlZRBCP7Ufz6y_xfp2ge1N0lDRyOBqmBL6vqQ/MYpxBtmM81U.jpg?size=2388x1080&quality=95&sign=8ba3200ea0a52f7ca02cf4720c6b25c4&type=album)  

#### 3. Начало уровня  
![image](https://sun9-14.userapi.com/impg/OHagFRqBvBHJOhGcna56nxIf7-z8_k4xAiUX1Q/iW1J6_bgxAs.jpg?size=2388x1080&quality=95&sign=4bd959a00cf4cc3018289746155811b3&type=album)  

#### 4. Готовка  
![image](https://sun9-11.userapi.com/impg/V-TS50iQTjOdRAbTOJQHnDtPueoHDiscHOA8oQ/BSctYLjpA-I.jpg?size=2388x1080&quality=95&sign=108e4b74a04c52125228f1932bd2a625&type=album)  

#### 5. Готово  
![image](https://sun9-21.userapi.com/impg/FIZS1exkoMCPwDL66bFrfHxU15bwvpg7WX0D6g/dxD_ZXTf6Gk.jpg?size=2388x1080&quality=95&sign=906a277e30631d7d00ab85e2c2b43024&type=album)  

#### 6. Недовольство, и хот дог на пути к цели  
![image](https://sun9-15.userapi.com/impg/-xJkisPrTqCsSqsI7QVh6k3xb-GR3XwKwoUJ7w/jVRqkLhZd14.jpg?size=2388x1080&quality=95&sign=e190cef0461db390392c084caff52997&type=album)  

#### 7. Конец уровня (в данном случае проигрыш)
![image](https://sun9-38.userapi.com/impg/piWerOMVxNNLr5QBp6ycMYJ-IPxgVvNX-HbeOw/J53DgHYIa1w.jpg?size=2388x1080&quality=95&sign=e0778bdd7b58b854c9eec157a0dbe16a&type=album)  