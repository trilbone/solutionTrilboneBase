<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:functx="http://www.functx.com"
exclude-result-prefixes="msxsl">

  <!--Скрипты  exclude-result-prefixes="msxsl"-->

  <xsl:output method="html" encoding="windows-1251" indent="yes"/>
  <!--корневой путь  -->
  <xsl:variable name="root" select="'http://info.trilbone.com/'"></xsl:variable>
  <xsl:variable name="arhivepath" select="'img/arhive/'"></xsl:variable>
  <xsl:variable name="smallpath" select="'small/'"></xsl:variable>
  <xsl:variable name="localpath"></xsl:variable>
  <!--Если фото не отображаются, то надо сгенерировать заново XML образца (а не взять из базы)-->

  <xsl:variable name="showimages" select="'true'"></xsl:variable>
  <xsl:variable name="numberstring" select="//@numberstring"></xsl:variable>
  <xsl:variable name="orderenabled" select="'true'"></xsl:variable>
  
  <!--переводим-->
  <xsl:variable name="grosslng" select="'Gross weight'"></xsl:variable>
  <xsl:variable name="showalllng" select="'Show all specimens..'"></xsl:variable>
  <xsl:variable name="qtylng" select="'Qty'"></xsl:variable>
  <xsl:variable name="pcslng" select="'pcs'"></xsl:variable>
  <xsl:variable name="totallng" select="'Total'"></xsl:variable>
  <xsl:variable name="tnwlng" select="'Total net weight'"></xsl:variable>
  <xsl:variable name="kglng" select="'kg'"></xsl:variable>
  <xsl:variable name="ytlng" select="'Your total'"></xsl:variable>
  <xsl:variable name="yslng" select="'Your discount'"></xsl:variable>
  <xsl:variable name="tsllng" select="'Total selected'"></xsl:variable>
  <xsl:variable name="csllng" select="'Count selected'"></xsl:variable>
  <xsl:variable name="salllng" select="'Show all specimens'"></xsl:variable>
  <xsl:variable name="fsnilng" select="'filter same name items'"></xsl:variable>
    <xsl:variable name="orderlng" select="'Order now'"></xsl:variable>


  <!--=====================================-->
  <xsl:template match="/">

    <!--main html document region-->
    <html>
      <style type="text/css">
        /* CSS Document */
        /*body*/
        .body_color {
        background-color:#cebf96;
        }
        .main_block {
        background-color:#d3cfb1;
        border-style: ridge;
        border-color: rgb(78,63,33);
        }
        /*caption*/
        .caption_sample {
        font-family: "Bodoni MT";
        font-size: x-large;
        font-style: normal;
        line-height: normal;
        font-weight: bold;
        color: rgb(78,63,33);
        text-align:center;
        vertical-align:top;
        }

        /*found in*/
        .locality {
        font-family: "Bodoni MT";
        font-size: large;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        }

        /*age field*/
        .age {
        font-family: "Bodoni MT";
        font-size: large;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        background-color: #c7acbd;
        text-align:center;
        }

        /*vid description*/
        .described {
        font-family: "Bodoni MT";
        font-size: large;
        font-style:normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        text-align:left;
        }

        /*size*/
        .size {
        font-family: "Bodoni MT";
        font-size: large;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        }

        /*remarks*/
        .remarks {
        font-family: "Bodoni MT";
        font-size: large;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        }

        /*addtext*/
        .addtext {
        font-family: "Bodoni MT";
        font-size: large;
        font-style: normal;
        line-height: normal;
        font-weight: normal;
        color: rgb(78,63,33);
        }

        /*barcode*/
        .bartext {
        font-family: "Bodoni MT";
        font-size: 10pt;
        font-style: normal;
        line-height: normal;
        font-weight: lighter;
        color: rgb(78,63,33);
        }

        /*Arrow*/
        .arrow
        {
        width: 20px;
        height: 20px;


        }

        /*body_color*/
        .body_color {
        background-color:#cebf96;
        font-family: "Bodoni MT";
        line-height: normal;
        font-size:small;
        color: rgb(78,63,33);
        }



        .hr_sample{
        height: 5px;
        background-color: rgb(78,63,33);
        }



        .hr_catalog{
        height: 7px;
        background-color: rgb(78,63,33);
        }



        .caption_catalog {
        background-color: #C0C0C0;
        font-size: x-large;
        font-weight: bold;
        text-align:center;
        vertical-align:top;
        }



        .div_main
        {
        display:block;
        left: 5%;
        top: 0px;
        height: 100%;
        }


        .NUMBER
        {
        font-size: x-small;
        font-weight: lighter;
        }

        .alt
        {
        font-size: medium;
        font-weight: bold;
        }


        .div_title
        {
        /*background-color: #C0C0C0;*/
        /*padding-left: 140px;*/
        font-size: large;
        align=center
        /*font-weight: bold;*/
        /*border : 1px inset #000000;*/
        }


        .div_upperright
        {
        font-size: medium;
        }



        .div_upperleft
        {
        font-size: medium;
        }


        .div_down
        {
        font-size: medium;
        }


        .div_image
        {
        width: 100%;
        }


        .sample_image
        {
        height : 171px;
        border : medium double #000000;
        }


        .summary
        {
        font-size: x-large;
        font-weight: bold;
        }

      </style>
      <!--<link rel="stylesheet" type="text/css" href="CatalogCSS.css" media="all"></link>-->
      <head>
        <META http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
        <!--Название каталога-->
        <title>
          <xsl:value-of select="//CATALOG/@name"/>
        </title>
        <!--иконка-->
        <link rel=" icon" href="favicon.ico" type="image/x-icon"></link>
        <!--Скрипты-->
        <script type="text/javascript">
          <xsl:comment>
            <![CDATA[
var _elem = new Array;
var _markSum = 0;
var _markCount = 0;


function showItems(itemnumberid, startnameid) {
    //??? ????? ?????? ??????
    var cbid = itemnumberid + startnameid + 1;
    //??? ????? 
    var cb = document.getElementById(cbid);
    var sample = document.getElementById(itemnumberid);
    //
    var allPtag = document.getElementsByTagName("span");
    var resultNo = new Array;

    //???? 
    if (cb.checked == false) {
        var tmp = document.getElementById("btShowAll");
        tmp.disabled = true;

        tmp = document.getElementById("btShowAllup");
        tmp.disabled = true;

        tmp = document.getElementById("ShowAllup");
        tmp.style.display = "none";

        tmp = document.getElementById("ShowAll");
        tmp.style.display = "none";

        for (var i = 0; i < _elem.length; i++) {
            _elem[i].style.display = "block";
        };
        _elem = new Array;
         return
       
    }
    //??? ??????? P

    //????????? ??? ? ??????? ?????? ? ?????? ??????(?? ??????? ?????)

    for (var i = 0; i < allPtag.length; i++) {
        var litem = allPtag.item(i).parentNode.parentNode.parentNode.parentNode;
        if (allPtag.item(i).getAttribute("name") != null) {
        var tagname=allPtag.item(i).getAttribute("name");
            if (tagname != startnameid & litem.tagName == "TBODY") {//? ????????? ?????? ??????????????? ???? table
                _elem.push(litem.parentNode.parentNode);
                litem.parentNode.parentNode.style.display = "none";
            }
            else {
                var tmp = document.getElementById("btShowAll");
                tmp.disabled = false;

                tmp = document.getElementById("btShowAllup");
                tmp.disabled = false;

                tmp = document.getElementById("ShowAllup");
                tmp.style.display = "block";

                tmp = document.getElementById("ShowAll");
                tmp.style.display = "block";
                
            }


        }
    }



}

function MarkItem(itemnumberid, startnameid) {
    var cbid = itemnumberid + startnameid + 2;
    var cb = document.getElementById(cbid);
    var sample = document.getElementById(itemnumberid);
    var _tmpid = itemnumberid + "PRICE";
    var _tmp = document.getElementById(_tmpid);

    if (cb.checked) {
        sample.style.color = "red"
        if (_tmp != null) {

            if (_tmp.hasChildNodes()) {
                var children = _tmp.lastChild;
                var value = children.nodeValue;

                if (value != null) {
                    value = value.replace(/[^0-9.]/g, "");
                    _markSum = _markSum + parseFloat(value);
                    _tmp = document.getElementById("totalselected");
                    _tmp.lastChild.nodeValue = "Total selected: " + _markSum;
                    _markCount = _markCount + 1;
                    _tmp = document.getElementById("countselected");
                    _tmp.lastChild.nodeValue = "Count selected: " + _markCount;

                    if (_markCount > 0) {
                        _tmp = document.getElementById("selected");
                        _tmp.style.display = "block";
                    }

                 
                    return
                }
            }
        }
    }


    else {
        sample.style.color = "rgb(78, 63, 33)";
        if (_tmp != null) {

            if (_tmp.hasChildNodes()) {
                var children = _tmp.lastChild;
                var value = children.nodeValue;

                if (value != null) {
                    value = value.replace(/[^0-9.]/g, "");
                    _markSum = _markSum - parseFloat(value);
                    if (_markSum < 0) _markSum = 0;
                    _tmp = document.getElementById("totalselected");
                    _tmp.lastChild.nodeValue = "Total selected: " + _markSum;
                    _markCount = _markCount - 1;
                     if (_markCount < 0) _markCount = 0;
                    _tmp = document.getElementById("countselected");
                    _tmp.lastChild.nodeValue = "Count selected: " + _markCount;

                   

                    if (_markCount == 0) {
                        _tmp = document.getElementById("selected");
                        _tmp.style.display = "none";
                    }

                    return
                }
            }
        }

    }

}
function showall() {
    var elem = document.getElementsByName("CheckBox")
    for (var i = 0; i < elem.length; i++) elem.item(i).checked = false;

    var tmp = document.getElementById("btShowAll");
    tmp.disabled = true;

    tmp = document.getElementById("btShowAllup");
    tmp.disabled = true;

    tmp = document.getElementById("ShowAllup");
    tmp.style.display = "none";

    tmp = document.getElementById("ShowAll");
    tmp.style.display = "none";

    for (var i = 0; i < _elem.length; i++) {
        _elem[i].style.display = "block";
    };
    _elem = new Array;

    return
    

}
          
          ]]>
          </xsl:comment>
        </script>
      </head>
      <body class="body_color" >
        <!--Общий блок========================================================== -->
        <!--атрибут left задает позйцию всего блока  -->
        <div class="div_main">
          <!--Рисунок шапки-->
          <div class="div_caption">
            <!--Назвние Каталога-->
            <p class="caption_catalog">
              <xsl:value-of select="//CATALOG/@title"/>
              <xsl:text>&#160;&#160;</xsl:text>
              <small>
                <xsl:value-of select="//CATALOG/@date"/>
              </small>
            </p>
          </div>
          <div id="ShowAllup" style="display:none">
            <!--вставить кнопку-->
            <button id="btShowAllup"  name="btShowAllup" disabled="false" onClick="showall();">
              <xsl:value-of select="$showalllng"/>
            </button>
          </div>
          <!--Начало блока образца======================================================== -->
          <xsl:if test="count(//SAMPLE)>0">
            <xsl:apply-templates select="//SAMPLE">
              <!--сортировка по названию-->
              <xsl:sort select="./DATA/ELEMENT[@name='NAME']/text()" data-type="text" />
            </xsl:apply-templates>
          </xsl:if>

          <xsl:if test="count(//CATALOGSAMPLE)>0">
            <xsl:apply-templates select="//CATALOGSAMPLE">
              <!--сортировка по названию-->
              <xsl:sort select="./DATA/ELEMENT[@name='NAME']/text()" data-type="text" />
            </xsl:apply-templates>
          </xsl:if>
          <!--Конец блока образца============================================================ -->

          <!--блок итогов для каталога============================-->
          <hr class="hr_catalog"  />
          <div class="summary">
            <!--вычисляем переменные-->
            <!--дерево с ретайл ценами-->
            <xsl:variable name="subthree_price">
              <xsl:for-each select="//ELEMENT[@name='PRICE']/text()">
                <xsl:element name="item">
                  <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
                </xsl:element>
              </xsl:for-each>
            </xsl:variable>
            <xsl:variable name="retail_sum" select="sum(msxsl:node-set($subthree_price)/item)"></xsl:variable>

            <xsl:variable name="currency_char" select="substring(string((//ELEMENT[@name='PRICE']/text()[1])),1,1)"/>

            <!--дерево со скидочными ценами-->
            <xsl:variable name="subthree_discount_price">
              <xsl:for-each select="//ELEMENT[@name='YOUPRICE']/text()">
                <xsl:element name="item">
                  <xsl:value-of select="number(translate(substring(.,2),',',''))"/>
                </xsl:element>
              </xsl:for-each>
            </xsl:variable>
            <xsl:variable name="discount_sum" select="sum(msxsl:node-set($subthree_discount_price)/item)"/>

            <!--дерево с весом-->
            <xsl:variable name="subthree_weight">
              <xsl:for-each select="//ELEMENT[@name='WEIGHT']/text()">
                <xsl:element name="item">
                  <xsl:value-of select="number(translate(translate(.,'kg',''),',',''))"/>
                </xsl:element>
              </xsl:for-each>
            </xsl:variable>
            <xsl:variable name="weight_sum" select="sum(msxsl:node-set($subthree_weight)/item ) div 1000"/>

            <!--дерево образцов-->
            <xsl:variable name="subthree_name">
              <xsl:for-each select="//SAMPLE">
                <xsl:element name="item">
                  <xsl:value-of select="@bar"/>
                </xsl:element>
              </xsl:for-each>
            </xsl:variable>
            <xsl:variable name="name_count" select="count(msxsl:node-set($subthree_name)/item)"/>

            <!--вывод итогов============>>>>>>-->
            <xsl:choose>
              <xsl:when test="$name_count>0">
                <p>
                  <pre>
                    <xsl:value-of select="$qtylng"/><xsl:text>:&#009;</xsl:text>
                    <!--кол-во-->
                    <xsl:value-of select="$name_count"/>
                    <xsl:text>&#160;</xsl:text>
                    <xsl:value-of select="$pcslng"/>
                  </pre>
                </p>
              </xsl:when>
            </xsl:choose>

            <!--общая сумма если 0 не отображается-->
            <xsl:choose>
              <xsl:when test="$retail_sum>0">

                <p>
                  <pre>
                    <xsl:value-of select="$totallng"/><xsl:text>:&#160;</xsl:text>
                    <!--сумма по ретайл ценам-->
                    <xsl:value-of select="concat($currency_char,string(format-number($retail_sum,'0.00')))"/>
                  </pre>
                </p>
              </xsl:when>
            </xsl:choose>

            <!--общий вес-->
            <xsl:choose>
              <xsl:when test="$weight_sum>0">

                <p>
                  <pre style="font-size: small;">
                    <xsl:value-of select="$tnwlng"/><xsl:text>:&#009;</xsl:text>
                    <xsl:value-of select="format-number(($weight_sum),'0.0')"/>
                    <xsl:text>&#160;</xsl:text><xsl:value-of select="$kglng"/>
                  </pre>
                </p>
              </xsl:when>
            </xsl:choose>
            <!--общая скидка если 0 не отображается-->
            <xsl:choose>
              <xsl:when test="$discount_sum>0">
                <p>
                  <pre>
                    <xsl:value-of select="$ytlng"/><xsl:text>:&#009;</xsl:text>
                    <!--сумма по ценам со скидкой-->
                    <xsl:value-of select="concat($currency_char,string(format-number($discount_sum,'0.00')))"/>
                  </pre>
                </p>
                <!--you save-->
                <hr />
                <p>
                  <pre style="font-size: small;">
                    <xsl:value-of select="$yslng"/><xsl:text>:&#009;&#009;</xsl:text>
                    <!--знак валюты-->
                    <xsl:value-of select="$currency_char"/>
                    <!--разница в ценах-->
                    <xsl:value-of select="format-number(($retail_sum - $discount_sum),'0.00')"/>
                  </pre>
                </p>
              </xsl:when>
            </xsl:choose>
            <hr />
            <div id="selected"  style="display:none">
              <p id="totalselected">
                <xsl:value-of select="$tsllng"/><xsl:text>:&#009;</xsl:text>
              </p>
              <p  id="countselected">
                <xsl:value-of select="$csllng"/><xsl:text>:&#009;</xsl:text>
              </p>
            </div>
            <div id="ShowAll" style="display:none">
              <button id="btShowAll"  name="btShowAll" disabled="true" onClick="showall();"><xsl:value-of select="$salllng"/></button>
            </div>
            <hr />
          </div>
        </div>
        <!--Конец страницы-->
      </body>
    </html>
  </xsl:template>

  <!--====================================-->
  <!--шаблон для образца-->
  <xsl:template match="SAMPLE">
    <!--Начальный Разделитель-->
    <!--ID поможет искать образец скриптами-->
    <div id="hr{@bar}">
      <hr class="hr_sample" />
      <xsl:apply-templates select="./DATA">
        <xsl:with-param name="number" select="@bar"></xsl:with-param>
        <xsl:with-param name="hash" select="./DATA/ELEMENT[@name='NUMBER']/@hash"></xsl:with-param>
        <xsl:with-param name="shot" select="./DATA/ELEMENT[@name='NUMBER']/text()"></xsl:with-param>
        <xsl:with-param name="foldertype" select="@imagefoldertype"></xsl:with-param>
      </xsl:apply-templates>
    </div>
  </xsl:template>
  <!--====================================-->
  <!--шаблон блока данных-->
  <xsl:template match="DATA">
    <xsl:param name="number"></xsl:param>
    <xsl:param name="hash"></xsl:param>
    <xsl:param name="shot"></xsl:param>
    <xsl:param name="foldertype"></xsl:param>

    <xsl:variable name="catnr" select="//CATALOG/@name"></xsl:variable>
    <xsl:variable name="buttonData" select="concat('number=',$number,';','catalognumber=',$catnr)"></xsl:variable>
    <xsl:variable name="itemName" select="substring-before (ELEMENT[@name='NAME']/text(), ' ')"></xsl:variable>
    <table id="{$number}" style="width:100%;" border="0">

      <tr>
        <!--Первая сторка таблицы -->
        <td id="title_block" style="width: 50%" valign="top">
          <!--Первая сторка таблицы. Левая ячейка -->
          <div>
            <!--вставить кнопку-->
            <form name="fmChecks">
              <input name="CheckBox" type="checkbox" id="{concat($number,$itemName,'1')}" value="{$itemName}" onchange = 'showItems("{$number}","{$itemName}");'><xsl:value-of select="$fsnilng"/></input>
              <xsl:text>&#160;&#160;</xsl:text>
              <input name="CheckBox" type="checkbox" id="{concat($number,$itemName,'2')}" value="{$itemName}" onchange = 'MarkItem("{$number}","{$itemName}");'>mark item</input>
              <!--заказ по номеру камня-->
              <xsl:choose>
                <xsl:when test="$orderenabled='true'">
                  <span>
                    <br/>
                    <button name="btOrderSample" disabled="true" formaction="http://www.trilbone.com/order" formenctype="text" formmethod="GET" value="{$buttonData}">
                      <xsl:value-of select="$orderlng"/>
                    </button>
                  <xsl:text>&#160;&#160;</xsl:text>
                  <xsl:value-of select="$numberstring"/>
                  <xsl:value-of select="$shot"/>
                  </span>
                </xsl:when>
                <xsl:otherwise>
                  <Br></Br>
                </xsl:otherwise>
              </xsl:choose>
            </form>
          </div>

          <!--создать титульный блок-->
          <div class="div_title">

            <!--создать номер-->

            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='title']">
              <xsl:with-param name="number" select="$number"></xsl:with-param>
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
          <br />
          <!--создать верхний левый блок-->
          <div class="div_upperleft">
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='upperleft']">
              <xsl:with-param name="number" select="$number"></xsl:with-param>
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>

        </td>
        <!--Первая сторка таблицы. Правая ячейка -->
        <td id="upperleft_block" valign="top">
          <!--создать верхний правый блок-->
          <div class="div_upperright">
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='upperright']">
              <xsl:with-param name="number" select="$number"></xsl:with-param>
              <xsl:sort select="@order"/>
            </xsl:apply-templates>

          </div>
        </td>
      </tr>



      <tr>
        <td id="down_block" colspan="2">
          <!--создать нижний блок (после картинок)-->
          <div class="div_down">
            <!--вставить поля данных-->
            <xsl:for-each select="ELEMENT[@position='down']">
              <xsl:variable name="pos" select="position()"></xsl:variable>
              <xsl:variable name="ord" select="@order"></xsl:variable>
              <xsl:variable name="tagprefix" select="@name"></xsl:variable>
              <xsl:variable name="tagsuffix" select="'DESCR'"></xsl:variable>
              <xsl:variable name="infolist" select="parent::node()/ELEMENT[@position='info'][@name=concat($tagprefix ,$tagsuffix)]"></xsl:variable>

              <!--main-->
              <xsl:apply-templates select=".">
                <xsl:with-param name="number" select="$number"></xsl:with-param>
                <xsl:sort select="@order"/>
              </xsl:apply-templates>
              <!--info-->
              <xsl:choose>
                <xsl:when test="boolean($infolist)">

                  <div class="div_info">
                    <!--вставить поля данных-->
                    <xsl:apply-templates select="$infolist">
                      <xsl:with-param name="number" select="$number"></xsl:with-param>
                      <xsl:sort select="@order"/>
                    </xsl:apply-templates>
                  </div>
                </xsl:when>
              </xsl:choose>


            </xsl:for-each>

          </div>
        </td>
      </tr>

      <!--вставить картинки-->
      <xsl:choose>
        <xsl:when test="$showimages = 'true'">
          <tr>
            <td colspan="2">
              <!--Блок изображений образца-->
              <xsl:apply-templates select="../IMAGES">
                <xsl:with-param name="number" select="$number"></xsl:with-param>
                <xsl:with-param name="hash" select="$hash"></xsl:with-param>
                <xsl:with-param name="shot" select="$shot"></xsl:with-param>
                <xsl:with-param name="foldertype" select="$foldertype"></xsl:with-param>
              </xsl:apply-templates>
            </td>
          </tr>
        </xsl:when>
      </xsl:choose>
    </table>


  </xsl:template>

  <!--==в вызове будем фильтровать по @position и @order=============================================-->
  <!--шаблон элемента блока-->
  <xsl:template match="ELEMENT">
    <xsl:param name="number"></xsl:param>
    <xsl:choose>
      <!--пропуск обработки элемента-->
      <xsl:when test="@name='TEST'">
      </xsl:when>

      <xsl:otherwise>
        <!--игнорировать NUMBER у него @alt=false-->
        <xsl:if test="@alt!='false'">
          <xsl:choose>
            <!--подчеркнутый абзац-->
            <xsl:when test="@underline='true'">
              <xsl:choose>
                <!--атрибут alt не пустой-->
                <xsl:when test="string-length(@alt)>0">
                  <span style="border: {@border}px outset rgb(78,63,33); text-decoration: underline; " >
                    <font class="alt">
                      <xsl:value-of select="@alt"/>
                      <xsl:text>:&#009;</xsl:text>
                    </font>
                    <xsl:value-of select="text()" disable-output-escaping="yes"/>
                    <xsl:apply-templates select="ENVIRONMENT">
                      <xsl:with-param name="link" select="text()[2]"/>
                    </xsl:apply-templates>
                  </span>
                  <br></br>
                </xsl:when>
                <!--без атрибута alt или с пустым атрибутом-->
                <xsl:otherwise>
                  <span style="font-style: italic; text-decoration: underline;">
                    <xsl:value-of select="text()" disable-output-escaping="yes"/>
                  </span>
                  <br></br>
                  <br></br>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:when>
            <!--не подчеркнутый абзац-->
            <xsl:otherwise>
              <xsl:choose>
                <xsl:when test="string-length(@alt)=0">
                  <!--без атрибута alt или с пустым атрибутом-->
                  <span style="font-style: italic">
                    <xsl:value-of select="text()" disable-output-escaping="yes"/>
                  </span>
                  <br></br>
                  <br></br>
                </xsl:when>
              
                <xsl:otherwise>
                    <!--атрибут alt не пустой-->
                  <xsl:choose>
                  <xsl:when test="@name='NAME'">
                      <span style="border: {@border}px outset rgb(78,63,33);"  name="{substring-before(text(),' ')}">
                    <font class="alt">
                      <xsl:choose>
                        <xsl:when test="@name='FOSSILSIZE'">
                          <xsl:choose>
                            <xsl:when test="contains(@alt,'(')">
                              <!--удалить скобки в размере-->
                              <!--скобки в начале - игнорить-->
                              <xsl:choose>
                                <xsl:when test="starts-with(@alt,'(')">
                                  <xsl:variable name="tmp" select="substring-after(@alt,')')"></xsl:variable>
                                  <xsl:variable name="start" select="substring-before(@alt,')')"></xsl:variable>
                                  <xsl:choose>
                                    <xsl:when test="contains($tmp,'(')">
                                          <xsl:value-of select="concat($start,normalize-space(substring-before($tmp,'(')))"/>
                                    </xsl:when>
                                  <xsl:otherwise>
                                     <xsl:value-of select="@alt"/>
                                  </xsl:otherwise>
                                  </xsl:choose>
                                </xsl:when>
                              <xsl:otherwise>
                                  <xsl:value-of select="normalize-space(substring-before(@alt,'('))"/>
                              
                              </xsl:otherwise>
                              </xsl:choose>
                            
                            
                            </xsl:when>
                            <xsl:otherwise>
                              <xsl:value-of select="@alt"/>
                            </xsl:otherwise>
                          </xsl:choose>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="@alt"/>
                        </xsl:otherwise>
                      </xsl:choose>
                      <xsl:text>:&#009;</xsl:text>
                    </font>
                    <xsl:value-of select="text()" disable-output-escaping="yes"/>
                    <xsl:if test="@name='WEIGHT'">
                      <br></br>
                      <span id="bw">
                        <font class="alt">
                          <xsl:value-of select="$grosslng"/><xsl:text>:&#009;</xsl:text>
                          <!--значение веса + 15%-->
                          <xsl:variable name="gross" select="round(number(translate(substring-before(text(),'kg'),',','.'))*1.15*1000)"/>
                          <xsl:choose>
                            <xsl:when test="string($gross) ='NaN'">

                            </xsl:when>
                            <xsl:otherwise>

                              <font style="font-size: x-small;">
                                <xsl:value-of select="concat($gross,'g')"/>
                              </font>
                            </xsl:otherwise>
                          </xsl:choose>
                        </font>
                      </span>
                    </xsl:if>
                    <xsl:apply-templates select="ENVIRONMENT">
                      <xsl:with-param name="link" select="text()[2]"/>
                    </xsl:apply-templates>
                  </span>
                  
                  </xsl:when>
                  <xsl:otherwise>
                      <span style="border: {@border}px outset rgb(78,63,33);"  >
                    <font class="alt">
                      <xsl:choose>
                        <xsl:when test="@name='FOSSILSIZE'">
                          <xsl:choose>
                            <xsl:when test="contains(@alt,'(')">
                              <!--удалить скобки в размере-->
                              <!--скобки в начале - игнорить-->
                              <xsl:choose>
                                <xsl:when test="starts-with(@alt,'(')">
                                  <xsl:variable name="tmp" select="substring-after(@alt,')')"></xsl:variable>
                                  <xsl:variable name="start" select="substring-before(@alt,')')"></xsl:variable>
                                  <xsl:choose>
                                    <xsl:when test="contains($tmp,'(')">
                                          <xsl:value-of select="concat($start,normalize-space(substring-before($tmp,'(')))"/>
                                    </xsl:when>
                                  <xsl:otherwise>
                                     <xsl:value-of select="@alt"/>
                                  </xsl:otherwise>
                                  </xsl:choose>
                                </xsl:when>
                              <xsl:otherwise>
                                  <xsl:value-of select="normalize-space(substring-before(@alt,'('))"/>
                              
                              </xsl:otherwise>
                              </xsl:choose>
                            
                            
                            </xsl:when>
                            <xsl:otherwise>
                              <xsl:value-of select="@alt"/>
                            </xsl:otherwise>
                          </xsl:choose>
                        </xsl:when>
                        <xsl:otherwise>
                          <xsl:value-of select="@alt"/>
                        </xsl:otherwise>
                      </xsl:choose>
                      <xsl:text>:&#009;</xsl:text>
                    </font>
                    <xsl:value-of select="text()" disable-output-escaping="yes"/>
                    <xsl:if test="@name='WEIGHT'">
                      <br></br>
                      <span id="bw">
                        <font class="alt">
                          <xsl:value-of select="$grosslng"/><xsl:text>:&#009;</xsl:text>
                          <!--значение веса + 15%-->
                          <xsl:variable name="gross" select="round(number(translate(substring-before(text(),'kg'),',','.'))*1.15*1000)"/>
                          <xsl:choose>
                            <xsl:when test="string($gross) ='NaN'">

                            </xsl:when>
                            <xsl:otherwise>

                              <font style="font-size: x-small;">
                                <xsl:value-of select="concat($gross,'g')"/>
                              </font>
                            </xsl:otherwise>
                          </xsl:choose>
                        </font>
                      </span>
                    </xsl:if>
                    <xsl:apply-templates select="ENVIRONMENT">
                      <xsl:with-param name="link" select="text()[2]"/>
                    </xsl:apply-templates>
                  </span>
                  
                  </xsl:otherwise>
                  </xsl:choose>
                
                  <br></br>
                </xsl:otherwise>
              </xsl:choose>
            </xsl:otherwise>
          </xsl:choose>
        </xsl:if>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>


  <!--==============================================-->
  <!--шаблон окружения-->
  <xsl:template match="ENVIRONMENT">
    <xsl:param name="link"></xsl:param>
    <a href="{@href}">
      <xsl:value-of select="$link"/>
    </a>
  </xsl:template>

  <!--==============================================-->
  <!--шаблон картинки-->
  <xsl:template match="IMAGES">
    <xsl:param name="number"></xsl:param>
    <xsl:param name="hash"></xsl:param>
    <xsl:param name="shot"></xsl:param>
    <xsl:param name="foldertype"></xsl:param>
    <xsl:choose>
      <xsl:when test="@titleimage='absolute'">
        <xsl:for-each select="IMAGE">
          <xsl:variable name="local" select="translate(@src,'\','/')"></xsl:variable>
          <a href="{$local}"  target="_blank" >
            <img class="sample_image" alt="image"  src="{$local}"  />
          </a>
        </xsl:for-each>
      </xsl:when>
      <xsl:otherwise>

        <xsl:for-each select="IMAGE">
          <xsl:variable name="local" select="concat('/',translate(@src,'\','/'))"></xsl:variable>
          <xsl:choose>
            <xsl:when test="$foldertype='shot'">
              <a href="{concat($root,$arhivepath,$shot,$local)}"  target="_blank" >
                <img class="sample_image" alt="image"  src="{concat($root,$arhivepath,$shot,$local)}"  />
              </a>
            </xsl:when>
            <xsl:when test="$foldertype='hash'">
              <a href="{concat($root,$arhivepath,$hash,$local)}"  target="_blank" >
                <img class="sample_image" alt="image"  src="{concat($root,$arhivepath,$hash,$local)}"  />
              </a>
            </xsl:when>
            <xsl:when test="$foldertype='ean13'">
              <a href="{concat($root,$arhivepath,$number,$local)}"  target="_blank" >
                <img class="sample_image" alt="image"  src="{concat($root,$arhivepath,$number,$local)}"  />
              </a>
            </xsl:when>
          </xsl:choose>
        </xsl:for-each>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>


</xsl:stylesheet>
