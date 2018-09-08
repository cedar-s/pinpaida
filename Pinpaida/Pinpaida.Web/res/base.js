$(function () {
    //选择品牌隐藏域赋值
    $('#brandlist li').click(function () {
        $('#brand').val($(this).attr('data-id'));
        $('#brandon').html($(this).html());
        $('#brandlist').hide();
    });

    //鼠标HOVER
    $('.brand-sel').hover(function () {
        $('#brandlist').show();
    }, function () {
        $('#brandlist').hide();
    });

    //搜索
    $('#btnsearch').click(function () {
        var brand = $('#brand').val();
        var word = $('#word').val();
        if (word != '') {
            window.location.href = '/search?brand=' + brand + '&word=' + encodeURIComponent(word);
        }
    });
});



(function (window) {
    window.PagerView = function (id, options) {
        var self = this;
        this.id = id;
        this.options = typeof options === 'undefined' ? {} : options;

        this._pageCount = 0; // 总页数
        this._start = 1; // 起始页码
        this._end = 1; // 结束页码

        /**
         * 当前控件所处的HTML节点引用.
         * @type DOMElement
         */
        this.container = null;
        /**
         * 当前页码, 从1开始
         * @type int
         */
        this.index = 1;
        /**
         * 每页显示记录数
         * @type int
         */
        this.size = 10;
        /**
         * 显示的分页按钮数量
         * @type int
         */
        this.maxButtons = 5;
        /**
         * 记录总数
         * @type int
         */
        this.itemCount = 0;

        /**
         *是否显示详细分页信息
         *@type bool
         */
        this.showDetails = true;

        /**
         *是否显示首页、末页
         *@type bool
         */
        this.showFirstLast = true;

        /**
         * 是否显示搜索跳转
         * @type bool
         */
        this.showSearch = typeof this.options.showSearch === 'undefined' ? false : this.options.showSearch;

        /**
         *需执行方法名
         * @type int
         */
        this.methodName = 'GetStrFormat';

        this.firstButtonText = '首页';
        this.lastButtonText = '末页';
        this.previousButtonText = '上一页';
        this.nextButtonText = '下一页';

        /**
         * 控件使用者重写本方法, 获取翻页事件, 可用来向服务器端发起AJAX请求.
         * 如果要取消本次翻页事件, 重写回调函数返回 false.
         * @param {int} index: 被点击的页码.
         * @returns {Boolean} 返回false表示取消本次翻页事件.
         * @event
         */
        this.onclick = function (index) {
            // modified by fj10854
            // 使参数能够使用"xxx.yyy.someMethod"这样传递方法名
            var methodName = this.methodName,
                nameSpaces = methodName.split('.'),
                parentMethodName = nameSpaces.shift(),
                parentMethod = window[parentMethodName];

            var temp = '';

            while (temp = nameSpaces.shift()) {
                parentMethod = parentMethod[temp] || (parentMethod[temp] = {});
            }

            if (typeof parentMethod === 'function') {
                parentMethod.call(null, index);
                return true;
            } else {
                return false;
            }
        };

        /**
         * 内部方法.
         */
        this._onclick = function (index) {
            var old = self.index;

            self.index = index;
            if (self.onclick(index) !== false) {
                self.render();
            } else {
                self.index = old;
            }
        };

        /**
         * 在显示之前计算各种页码变量的值.
         */
        this._calculate = function () {
            self._pageCount = parseInt(Math.ceil(self.itemCount / self.size));
            self.index = parseInt(self.index);
            if (self.index > self._pageCount) {
                self.index = self._pageCount;
            }
            if (self.index < 1) {
                self.index = 1;
            }

            self._start = Math.max(1, self.index - parseInt(self.maxButtons / 2));
            self._end = Math.min(self._pageCount, self._start + self.maxButtons - 1);
            self._start = Math.max(1, self._end - self.maxButtons + 1);
        };

        /**
         * 获取作为参数的数组落在相应页的数据片段.
         * @param {Array[Object]} rows
         * @returns {Array[Object]}
         */
        this.page = function (rows) {
            self._calculate();

            var s_num = (self.index - 1) * self.size;
            var e_num = self.index * self.size;

            return rows.slice(s_num, e_num);
        };

        /**
         * 渲染控件.
         */
        this.render = function () {
            var div = document.getElementById(self.id);
            div.view = self;
            self.container = div;

            self._calculate();

            var str = '';
            str += '<div class="PagerView">\n';
            if (self._pageCount > 1) {
                if (self.index != 1) {
                    if (this.showFirstLast) {
                        str += '<a href="javascript://1"><span>' + this.firstButtonText + '</span></a>';
                    }
                    str += '<a href="javascript://' + (self.index - 1) + '"><span>' + this.previousButtonText + '</span></a>';
                } else {
                    if (this.showFirstLast) {
                        str += '<span>' + this.firstButtonText + '</span>';
                    }
                    str += '<span>' + this.previousButtonText + '</span>';
                }
            }
            for (var i = self._start; i <= self._end; i++) {
                if (i == this.index) {
                    str += '<span class="on">' + i + '</span>';
                } else {
                    str += '<a href="javascript://' + i + '"><span>' + i + '</span></a>';
                }
            }
            if (self._pageCount > 1) {
                if (self.index != self._pageCount) {
                    str += '<a href="javascript://' + (self.index + 1) + '"><span>' + this.nextButtonText + '</span></a>';
                    if (this.showFirstLast) {
                        str += '<a href="javascript://' + self._pageCount + '"><span>' + this.lastButtonText + '</span></a>';
                    }
                } else {
                    str += '<span>' + this.nextButtonText + '</span>';
                    if (this.showFirstLast) {
                        str += '<span>' + this.lastButtonText + '</span>';
                    }
                }
            }
            if (this.showSearch && self._pageCount > 1) {
                str += '<div class="pagerView-search">跳转到<input type="number" class="eui-input"><button type="button" class="eui-btn eui-btn-primary">GO</button></div>';
            }
            if (this.showDetails && self.itemCount > 0) {
                str += ' 共' + self._pageCount + '页, ' + self.itemCount + '条记录 ';
            }
            str += '</div><!-- /.pagerView -->\n';

            self.container.innerHTML = str;

            var a_list = self.container.getElementsByTagName('a');
            for (var i = 0; i < a_list.length; i++) {
                a_list[i].onclick = function () {
                    var index = this.getAttribute('href');
                    if (index != undefined && index != '') {
                        index = parseInt(index.replace('javascript://', ''));
                        self._onclick(index);
                    }
                    return false;
                };
            }

            var goBtn = self.container.getElementsByTagName('button')[0];
            if (goBtn != null) {
                var pageInput = self.container.getElementsByTagName('input')[0];
                goBtn.onclick = function () {
                    var index = pageInput.value;
                    if (index != null && ('' + index).trim() !== '') {
                        self._onclick(index);
                    }
                }
            }
        };
    };
})(window);