/// 應用於 ASP.NET MVC 中的 ViewBag
/// 為ViewBag 指定第二層物件參數
/// 此例用以帶查詢參數(qryParam)，表單編號等，到 View 查詢表單並編輯。
public ActionResult Edit(int id)
{
    ViewBag.qryParam = new ExpandoObject(); // 第二層物件
    ViewBag.qryParam.Sn = id;  // 查詢參數
    ViewBag.qryParam.Name = '';  // 查詢參數

    return View();  // 到 View 查詢表單並編輯。
}
