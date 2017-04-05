<?xml version="1.0" encoding="windows-1251"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" 
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="html" encoding="windows-1251" indent="yes"/>
  <!--корневой путь  -->
  <xsl:variable name="root"></xsl:variable>
  
  <xsl:template match="/">
     <!--main html document region-->
      <html>
        <style type="text/css">
          /* цвет страницы */
          .body_color {
          background-color:#cebf96;
          font-family: "Bodoni MT";
          line-height: normal;
          font-size:small;
          color: rgb(78,63,33);
          }


          /*разделитель образцов*/
          .hr_sample{
          height: 5px;
          background-color: rgb(78,63,33);
          }

          
          /*разделитель старт-стоп*/
          .hr_catalog{
          height: 7px;
          background-color: rgb(78,63,33);
          }
          
          
          /*заголовок каталога*/
          .caption_catalog {
          background-color: #C0C0C0;
          font-size: x-large;
          font-weight: bold;
          text-align:center;
          vertical-align:top;
          }

          
          /*основной блок страницы*/
          .div_main
          {
          display:block;
          /*position:absolute;*/
          left: 5%;
          top: 0px;
          height: 100%;
          }

          /*номер образца */
          .NUMBER
          {
          font-size: x-small;
          font-weight: lighter;
          }
            /*alt тег */
          .alt
          {
          font-size: medium;
          font-weight: bold;
          }
          
          /*титульный блок @position=title*/
          .div_title
          {
          /*background-color: #C0C0C0;*/
          padding-left: 140px;
          font-size: medium;
          /*font-weight: bold;*/
          /*border : 1px inset #000000;*/
          }

          /*верхний правый блок @position='upperright'*/
          .div_upperright
          {
          font-size: medium;
          }


          /*верхний левый блок @position='upperleft'*/
          .div_upperleft
          {
          font-size: medium;
          }
          
          /*нижний блок*/
          .div_down
          {
          font-size: medium;
          }

          /*блок картинок*/
          .div_image
          {
          width: 100%;
          }

          /*картинка образца*/
          .sample_image
          {
          height : 171px;
          border : medium double #000000;
          }
          
          /*итоговый блок*/
          .summary
          {
          font-size: x-large;
          font-weight: bold;
          }
        </style>
        <!--
        <link rel="stylesheet" type="text/css" href="CatalogCSS.css" media="all"></link>-->
        <head>
         
          <META http-equiv="Content-Type" content="text/html; charset=windows-1251"/>
           
          <!--Название каталога-->
          <title>
            <xsl:value-of select="//CATALOG/@name"/>
          </title>
          <!--Скрипты-->
          <!--пока нет-->
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
                <small> <xsl:value-of select="//CATALOG/@date"/> </small>
              </p>
            </div>
            <!--Начало блока образца======================================================== -->
            <xsl:apply-templates select="//SAMPLE">
              <!--сортировка по названию-->
              <xsl:sort select="./DATA/ELEMENT[@name='NAME']/text()" data-type="text" />
            </xsl:apply-templates>
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
             <xsl:variable name="weight_sum" select="sum(msxsl:node-set($subthree_weight)/item)"/>
             
             <!--дерево образцов-->
             <xsl:variable name="subthree_name">
               <xsl:for-each select="//SAMPLE">
                 <xsl:element name="item">
                   <xsl:value-of select="@bar"/>
                 </xsl:element>
               </xsl:for-each>
             </xsl:variable>
             <xsl:variable name="name_count" select="count(msxsl:node-set($subthree_name)/item)"/>
             
             <!--знак валюты (берется из атрибута price)-->
             <xsl:variable name="currency_char" select="substring-before(//ELEMENT[@name='PRICE']/text(),1)"/>
             
             <!--вывод============>>>>>>-->
             <xsl:choose>
               <xsl:when test="$name_count>0">
             <p>
               <pre>
                 <xsl:text>Qty:&#009;&#009;&#009;</xsl:text>
               <!--кол-во-->
               <xsl:value-of select="$name_count"/>
               <xsl:text>&#160;pcs</xsl:text>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
                 
      <!--общая сумма если 0 не отображается-->
      <xsl:choose>
      <xsl:when test="$retail_sum>0">       

                <p>
               <pre>
               <xsl:text>total:&#009;</xsl:text>
                <!--знак валюты-->
                <xsl:value-of select="$currency_char"/>
                <!--сумма по ретайл ценам-->
                <xsl:value-of select="format-number($retail_sum,'0.00')"/>
                </pre> 
                </p>
      </xsl:when>
     </xsl:choose>
             
               <!--общий вес-->
             <xsl:choose>
               <xsl:when test="$weight_sum>0">

                 <p>
               <pre style="font-size: small;">
                 <xsl:text>Total net weight:&#009;</xsl:text>
                 <xsl:value-of select="format-number(($weight_sum),'0.0')"/>
                 <xsl:text>&#160;kg</xsl:text>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
             <!--общая скидка если 0 не отображается-->
             <xsl:choose>
               <xsl:when test="$discount_sum>0">
                  <p>
               <pre>
               <xsl:text>Your total:&#009;</xsl:text>
               <!--знак валюты-->
               <xsl:value-of select="$currency_char"/>
               <!--сумма по ценам со скидкой-->
               <xsl:value-of select="format-number($discount_sum,'0.00')"/>
               </pre>
             </p>
                   <!--you save-->
             <hr />
             <p>
               <pre style="font-size: small;"> <xsl:text>You save:&#009;&#009;</xsl:text>
               <!--знак валюты-->
               <xsl:value-of select="$currency_char"/>
               <!--разница в ценах-->
               <xsl:value-of select="format-number(($retail_sum - $discount_sum),'0.00')"/>
               </pre>
             </p>
               </xsl:when>
             </xsl:choose>
             <hr />
          </div>
            
          </div>
          <!--Конец общего блока-->

        </body>

          </html>
</xsl:template>
  
  <!--====================================-->
  <!--шаблон для образца-->
  <xsl:template match="SAMPLE">
    <!--Начальный Разделитель-->
    <!--ID поможет искать образец скриптами-->
    <hr id="{@bar}"  class="hr_sample" />
    <xsl:apply-templates select="./DATA">
      <xsl:with-param name="number" select="@bar"></xsl:with-param>
    </xsl:apply-templates>
    <!--Конечный разделитель
    <hr class="hr_sample" /> -->
  </xsl:template>
  
  <!--=============================================-->
  <!--шаблон блока данных-->
  <xsl:template match="DATA">
    <xsl:param name="number"></xsl:param>
    <table style="width:100%;">
      <tr>
        <td id="title_block" style="width: 50%" valign="top">
          <!--создать титульный блок-->
          <div class="div_title">
            <!--создать номер-->
            <p class="NUMBER">
              <xsl:value-of select="//CATALOG/@numberstring"/>
              <xsl:text>:&#009;</xsl:text>
              <xsl:value-of select="$number"/>
            </p>
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='title']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>

          <br />

          <!--создать верхний левый блок-->
          <div class="div_upperleft">
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='upperleft']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
        <td id="upperleft_block" valign="top">
          <!--создать верхний правый блок-->
          <div class="div_upperright">
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='upperright']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
      </tr>
      <tr>
        <td id="image_block" colspan="2">
          <!--вставить картинки-->
          <!--Блок изображений образца-->
          <br/>
          <div class="div_image">
            <xsl:apply-templates select="../IMAGES/IMAGE"></xsl:apply-templates>
          </div>
          <br/>
        </td>
      </tr>
      <tr>
        <td id="down_block" colspan="2">
          <!--создать нижний блок (после картинок)-->
          <div class="div_down">
            <!--вставить поля данных-->
            <xsl:apply-templates select="ELEMENT[@position='down']">
              <xsl:sort select="@order"/>
            </xsl:apply-templates>
          </div>
        </td>
      </tr>
    </table>

    
  </xsl:template>
 
  <!--==в вызове будем фильтровать по @position и @order=============================================-->
  <!--шаблон элемента блока-->
  <xsl:template match="ELEMENT">
    <!--Поле-->
    
    <p>
      <font class="alt"> <xsl:value-of select="@alt"/>
        <xsl:text>:&#009;</xsl:text></font>
         <xsl:value-of select="text()"/>
       <xsl:apply-templates select="ENVIRONMENT">
         <xsl:with-param name="link" select="text()[2]">
         </xsl:with-param>
       </xsl:apply-templates>
      
    </p>
    
    
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
  <xsl:template match="IMAGE">


    <!-- <a href="{../../@bar}/{@src}" target="_blank" title="Click to enlarge">
    <img class="sample_image" alt="{@src}"  src="{../../@bar}/{@src}"  />
    </a> -->
    <a href="{@src}" target="_blank" title="Click to enlarge">
      <img class="sample_image" alt="{@src}"  src="{@src}"  />
    </a>
  </xsl:template>
  
  
</xsl:stylesheet>
