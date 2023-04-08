# ForeSight Blog.App Projesi

Medium benzeri bir blog içerik yönetimi sistemi olarak tasarladığım bu projede;

* Mail ile üyelik oluşturma ve giriş yapma,
* Kullanıcının takip ettiği etiketlere göre ilgili makalelerin ana sayfada gösterimi,
* Kullanıcıya kendilerini ifade edebilecekleri yazı tipleri, kalınlık-incelik ayarları, resim ve tag ekleme gibi özelliklerle blog yazma imkanı sunma,
* Trend Makaleler(En Beğenilenler), En Son Yayınlanan Makaleler ve En Çok Okunan Makaleler gibi listelerin yanı sıra ilgili konulara göre filtreleme seçenekleri
* Kullanıcıları takip etme, makale beğenme ve yorum yapma alanları
* Basit, sade ve kullanışlı kullanıcı arayüzü bulunmaktadır.

![image](https://user-images.githubusercontent.com/119038121/230676013-0f9db04c-1cf0-4910-ae60-cee7a31dee2b.png)
![image](https://user-images.githubusercontent.com/119038121/230680200-1e8da2ba-5727-4a85-95d0-26dbc4449aa5.png)
![image](https://user-images.githubusercontent.com/119038121/230680391-fd95a6f2-ac88-4925-8327-e638f1896e86.png)
![image](https://user-images.githubusercontent.com/119038121/230680617-a8a06409-a4dd-415a-837d-6797246a9fb4.png)
![image](https://user-images.githubusercontent.com/119038121/230683420-2ef54cfd-064d-45eb-bc91-24b6cbc40abf.png)


Proje .NET CORE MVC ile geliştirilmiş olup, OOP(Object Oriented Programming) yaklaşımı benimsenmiştir. Bununla beraber proje framework'unde aşağıdaki yapılar 
kullanılmıştır; 
* N-Tier Architecture 
* Generic Repository ve UnitofWork
* Dependency Injection
* Global Filter

<table border="1" cellpadding="1" cellspacing="1" style="width:500px">
	<tbody>
		<tr>
			<td><strong>&Ouml;zellikler</strong></td>
			<td><strong>Kullanılan Teknolojiler</strong></td>
		</tr>
		<tr>
			<td>Blog yazma alanı</td>
			<td>CK Edit&ouml;r</td>
		</tr>
		<tr>
			<td>Ana sayfadaki makale Listeleme Alanları</td>
			<td>ViewComponent</td>
		</tr>
		<tr>
			<td>Mail ile giriş ve &uuml;yelik oluşturma</td>
			<td>SmtpClient</td>
		</tr>
		<tr>
			<td>İşlem sonrasında notification oluşturma</td>
			<td>Toaster (Javascript)</td>
		</tr>
		<tr>
			<td>Blog yazma alanındaki tag ekleme alanı</td>
			<td>AutoComplete&nbsp;(Javascript)</td>
		</tr>
		<tr>
			<td>CRUD İşlemleri&nbsp;</td>
			<td>Ajax</td>
		</tr>
	</tbody>
</table>

