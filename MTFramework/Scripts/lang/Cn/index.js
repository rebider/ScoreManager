﻿var weblang = {
    //公用
    // 'Exp': 'Exp',//Exp标题
    'bank_transfer1': '银行汇款',//银行汇款
    'money_transfer': '货币转移',//货币转移
    'status_failed': '失败',//失败
    'status_success': '成功',//成功
    'status_check':'审核中',
    'username_cn': '中文名',
    'username': '英文名/拼音姓名',
    'success': '保存成功',
    'levelAgent': '上级代理号 ',
    'IBNum': '代理号 ',
    'error': '保存失败',
    'my_account': '我的账户',
    'my_profile': '我的资料',
    'golden': '入金',
    'withdraw': '出金',
    'agency': '代理',
    'agency1': '代理用户',
    'log_off': '退出登录',
    'leverage': '杠杆',
    'type': '类型',
    'wallet': '钱包',
    'trading_account': '交易账户',
    'trading_accountname': '现交易账户名',
    'trading_accountNewname': '新交易账户名',//修改交易账户名（新账户名）
    'phone': '手机号码',
    'email': '邮箱',
    'emai': '邮箱',
    'westfield_wallet': ' 钱包',
    'currency_type': '货币种类',
    'manage_wallet': '管理我的钱包',
    'transfer_accounts': '转出账户',
    'into_account': '转入账户 <span style=\'color:red\'>(邮箱)</span>',
    'sum': '金额',
    'c_account': '转出账户如果是钱包 则转入账户只能是交易账户,如果转出账户是交易账户 则传入账户只能是钱包',
    'records': '资金管理记录',
    'date_time': '日期/时间',
    'way': '方式',
    'source_account': '源账户',
    'target_account': '目标账户',
    'money': '资金',
    'converted': '内转',
    'capital': '外转',
    'Rotation_remarks': '<i style="color:#f02a4a;">*</i> <i style="color:#cad4de;">该方式仅限于钱包与个人MT4账户之间内转，不适用于客户钱包之间互转。</i>',//自转备注
    'Inside_notes': '<i style="color:#f02a4a;">*</i>该方式仅限于代理下发佣金给客户使用。一旦转出，所填数额将被冻结，等待审核。<br/>  若审核通过，冻结金额将转入所填客户钱包。<br/>若审核未通过，冻结金额将返还到当前客户钱包。',//内转备注
    'rotation': '自转',
    'remark': '备注',
    'remark_crm': '客户crm显示备注',
    'remark_mt4': '客户mt4显示备注',
    'commission': '佣金',
    'net_silver': '网银',
    'system': '系统',
    'current_balance': '现余额',
    'convert': '转换为人民币',
    'convert1': '转换为人民币(￥)',
    'display_credit': '显示余额',
    'choose': '选择',//
    'important_items': '重要事项',
    'state': '状态',
    'volume': '成交量',
    'operate': '操作',
    'save': '保存',
    'close': '关闭',
    'select': '请选择',
    'return': '返回上级列表',
    'total': '共有',
    'record': '条',
    'perpage': '每页显示',
    'update_info': '修改信息',
    'chinese': '中文',
    'english': '英文',
    'man': '男',
    'woman': '女',
    'birthday': '出生日期',
    'nodata': '暂无数据',
    'Accountname': '帐户名 :',
    'logemail':'登录名',
    'User_Auth': '用户认证',
    'detail': '下级详情',
    'date': '起止日期',
    'your_email': '您的邮箱',
    'd_password': '登录密码',
    'asd': '验证码',
    'account_no': '还没有账号？',
    'go_register': '立即注册',
    'sureapply':'确认申请',

    
    //注册界面开始--------------------------------------------------------------------------
    'r_customer_registration': '客户注册专区',
    'r_personal_information': '根据<span style="color:#f02a4a">FCA</span>及<span style="color:#f02a4a">FSP</span>的合规监管要求，需要您<span style="color:#f02a4a">如实填写</span>KYC注册问卷信息，否则将会造成您的账户申请审核进度<span style="color:#f02a4a">被延迟</span>。请注意 <span style="color:#f02a4a">*</span> 为<span style="color:#f02a4a">必填项</span>',
    'r_regulator': '请选择监管机构',
    'r_england_FSA': '英国FCA',
    'r_perInfo': '个人信息',
    'r_sex': '<span style=\'color:#f02a4a;\'>*</span>性别',
    'r_username_cn': '<span style=\'color:#f02a4a;\'>*</span> 中文名',
    'r_username': '<span style=\'color:#f02a4a;\'>*</span> 英文名/拼音姓名',
    'r_country': '<span style=\'color:#f02a4a;\'>*</span> 居住国家',
    'r_zip': '<span style=\'color:#f02a4a;\'>*</span> 邮编',
    'r_address': '<span style=\'color:#f02a4a;\'>*</span> 地址',
    'r_phone':'<span style=\'color:#f02a4a;\'>*</span> 手机号码',
    'r_email': '<span style=\'color:#f02a4a;\'>*</span> 邮箱',
    'r_confirmemail': '<span style=\'color:#f02a4a;\'>*</span> 确认邮箱',
    'r_emailinfo':'<span style=\'color:#f02a4a;\'>（请务必填写您自己的个人邮箱）</span>',
    'r_ibcode': '经纪人代码',
    'r_password': '<span style=\'color:#f02a4a;\'>*</span> 密码',
    'r_confirmpassword': '<span style=\'color:#f02a4a;\'>*</span> 确认密码',
    'r_Area': '<span style=\'color:#f02a4a;\'>*</span> 省市区',
    'r_noteInfo':'(请注意 * 为必填项)',
    'Area': '省市区',
    'province': '请选择省',
    'city': '请选择市',
    'area1': '请选择县/区',
    'Nz': '新西兰FSP',
    //注册界面结束--------------------------------------------------------------------------


    'typecode': '代理类型代码',
    'c_UserType': '用户类型',
    'ChangePwd': "修改密码",
    'Login': '账<span style="margin-left:15px;"></span>号',


    'Zip': '邮编',
    'Area': '省市区',
    'province': '请选择省',
    'city': '请选择市',
    'area1': '请选择县/区',   
    'Nz': '新西兰FSP',
    'sex': '性别',
    'country': '居住国家',
    'surnames': '姓氏',
    'LoginCenter': '客户登录中心',
    'IBLoginCenter': '代理登录中心',
    'email_confirmation': '邮箱确认',
    'introducing_broker': '介绍经纪人（IB）代码',
    'write': '如果客户以代理链接开户，此代码要自动生成，如果不是可以空，也可手动填写',
    'c_password': '客户后台密码',
    'keep': '客户后台ID将会是您填写的邮箱地址，请保存好此密码，您需要通过客户后台开通交易账户！',
    'passwor': '密<span style="margin-left:15px;"></span>码',
    'Password': '密码',
    'confirm_password': '确认密码',
    'Password1': '新密码',
    'confirm_password1': '确认新密码',
    'asd': '验证码',
    'NextAutoLogin': '下次自动登录',
    'Home': '返回主页',
    'Forgetpassword': '忘记密码?',
    'Signin': '登录',
    'register': '注册',
    'open_account': '申请开户',
    'rlogin_to':'返回登录',
    //注册成功后的反馈页面
    'info': '您的申请已经成功发送，我们将反馈的信息发送至您个人电子邮箱，请查收如有疑问请发送邮件至。。。。此处邮箱在SystemParam里面设置',
    //我的账户
    'agentLevel': '代理级别 ',
    'agentKinds': '代理类型 ',
    'rebate_Type':'返佣类型 ',
    'money_management': '管理资金',
    'account': '账户',
    'myaccount': '我的账户',
    'cus_trun': '同一客户内转',
    'user_turn': '代理佣金下发',
    'user_turn_form': '代理佣金下发申请表',
    'free_margin': '可用保证金',
    'account_balance': '账户余额',
    'submit_application': '提交申请',
    'account_GroupName': '分组',
    'operation': '出入金操作',
    'MT4_account': '开设MT4同名账户',
    'into': '转入',
    'reason':'(原因:123)',
    'roll_out': '转出',
    'Designatedmailbox':'给账户绑定后台ID(邮箱)',

    'apply_state': '杠杆申请状态 :',

    'watting_apply': '待审核',
    'had_passed': '已通过',
    'had_failed': '已拒绝',
    'equity': '净值',
    'profit': '持仓盈亏',
    'sure_apply':'确认申请',

    'MT4_Status': 'MT4账户申请状态 :',

    'prompt': '提示',
    'confirm_account': '您确定重置该MT4交易账户密码？确定之后，新密码发送至您账户邮箱中，请注意查收。',//
    'reset': '重置密码',
    'reset1': '找回密码',
    'modify': '修改杠杆',
    'modifyname': '修改账户名',
    'confirm': '确定',
    'cancel': '取消',
    'leveragelist': '可选杠杆',
    'normal': '正常',//正常
    'lock': '锁定',//锁定
    'applying': '申请中',//申请中
    'real_account':'真实账户',
    'typeone': '标准账户',
    'typetwo': '专业账户',
    'typethree': '模拟账户',
    'select_type': '请选择账户',
    'saving': '保存中...',
    'getmoneyfaild': '获取钱包余额失败',
    'reset_confirm': '您确定重置登录密码？',//确定之后，新密码发送至您账户邮箱中，请注意查收。
    'tip': '确定之后，修改密码链接发送到您的邮箱，请注意查收',
    'tip1': '确定之后，请使用新密码登陆客户端',
    'tip_1':'提示',
    'resetting': '重置中……',
    'confirm_change': '确认调整？',
    'noverify': '您的账户尚未激活，暂时不能创建交易账户',
    'iknow': '我知道了',
    'goverify': '去激活',
    'seeverify': '查看激活结果',
    'failedverify': '账户激活失败，不能创建交易账户',
    'verifying': '激活中，暂时不能创建交易账户，请耐心等待……',
    'takeall':'一键转出',
    //开设MT4交易账户
    'creat_账户': '创建MT4账户',
    'account_type': '账户类型', 
    'currency': '货币',
    'trade_accounts': '创建MT4交易账户',
    'mt4account':'MT4账户',
    //管理资金
    'surepay': '确认转账',
    'account_select': '请选择转入转出账户',
    'write_money': '请填写转账金额',
    'transfer': '转账中',//转账中
    'wallet_balance': '钱包',
    'morethanzero': '必须大于0',
    //代理专区
   ' mt4_Account':'MT4交易账户',
   'pro_money':'持仓盈亏',
   'trade_record': '交易记录',
   'hands_account':'手数',
   'trade_kinds': '交易品种',
   'accountInfo':'账户详情',
    //我的资料
    
   
    'per_data': '个人信息',
    'user_info': '用户信息',
    'my_wllet': '我的钱包',
    'bank_card': '银行卡',
    'nationality': '国籍',
    'language': '语言',
    'address': '地址',
    'authentication': '认证方式',
   
    'ID_mumber': '证件号码',
    'currcertificationency': '未激活，现在去',
    'Notcertifiednowgo': '未激活,现在去',
    'Authentication': '激活',
    'Authenticationsuccess': '激活成功',
    'Authenticationfailednowgo': '激活失败,现在去',
    'UserInfoedit': '修改',
    'Administration':'管理',

    //实名认证
    'Vusername_cn': '中文名',
    'Vusername': ' 英文名',
    'LookInfo':'<span style=\'color:red\'>(查看资料)</span>',
    'VIDcard': '<span style="color: #dc143c;font-size:18px">*</span> 证件号码',
    'VBirthday': '<span style="color: #dc143c;font-size:18px">*</span> 出生日期',
    'id_photo': '证件正面照片',
    'id_photo2': '证件反面照片',
    'positive': '点击上传证件正面',
    'opposite': '点击上传证件反面',
    'card_photo': '银行卡正面',
    'card_photo1': '银行卡反面',
    'up_cardphoto': '点击上传银行卡正面',
    'up_cardphoto1': '点击上传银行卡反面',
    'address_info': '地址信息',
    'proof_addr': '地址证明',
    'up_addr': '点击上传地址文件证明',
    'verify_result': '认证结果: ',
    'notconfirm_name': '<i style="margin-right:5px;color:#f67467;margin-left:10px;">X</i>姓名不符',
    'notconfirm_idno': '<i style="margin-left:10px;color:#f67467;">X</i> 身份证号不符',
    'notconfirm_cardtype': '<i style="margin-left:10px;color:#f67467;">X</i> 银行卡类型不符',
    'notconfirm_banktype': '<i style="margin-left:10px;color:#f67467;">X</i> 开户行名称不符',
    'notconfirm_cardno': '<i style="margin-left:10px;color:#f67467;">X</i> 银行卡号不符',
    'notclear_bankcard': '<i style="margin-left:10px;color:#f67467;">X</i> 银行卡照片不清晰',
    'notclear_id': '<i style="margin-left:10px;color:#f67467;">X</i> 身份证照片不清晰',
    'notconfirm_bankaddress': '<i style="margin-left:10px;color:#f67467;">X</i> 开户行地址不符',
    'notconfirm_addressinfo': '<i style="margin-left:10px;color:#f67467;">X</i> 地址信息不符',
    'notclear_addr': '<i style="margin-left:10px;color:#f67467;">X</i> 地址照片不清晰',
    'not_8': '<i style="margin-left:10px;color:#f67467;">X</i> 地址信息不符',
    'not_9': '<i style="margin-left:10px;color:#f67467;">X</i> 	银行卡照片未上传',
    'not_10': '<i style="margin-left:10px;color:#f67467;">X</i> 证件照片未上传',
    'not_11': '<i style="margin-left:10px;color:#f67467;">X</i> 证件照片不符',
    'not_12': '<i style="margin-left:10px;color:#f67467;">X</i> 银行卡照片不符',
    'not_13': '<i style="margin-left:10px;color:#f67467;">X</i> 信息填写错误',
    'not_14': '<i style="margin-left:10px;color:#f67467;">X</i> 证件失效',
    'example': '示例',//示例
    'submit': '提交认证',
    'identify_test': '<span style="color: #dc143c">身份激活中......</span> ',
    'certification': '您的账号已激活，无需再激活!',
    'authenticationfailed': '激活失败，去',
    //入金1
    'golden_options': '入金选项',
    'bank': '这种方式可以从您的银行账户中直接汇款至您在账户当中。银行电汇允许您存入您的本地货币。然后由收款银行转换为您存款选定接受的货币。',
    'online': '使用在线支付的方式，可以让您在中国享受快捷的存取款服务。汇率是以当日中国银行在岸人民币现汇买入/卖出汇率折算。',
    'online1': '您的银行卡扣除的是人民币，交易账户中到账的货币为您选定的货币（一般为美金）。',
    'online2': '基于反洗钱的条规，通过人民币在线入金的客户，出金时也会以人民币方式出金到个人账户。',
    'visa': '使用信用卡/借记卡付款是将资金存入您交易账户简单且安全的方式。',
    'master_card': '使用信用卡/借记卡付款是将资金存入您交易账户简单且安全的方式。',
    'paypal': '通货膨胀在一个小时内计入您的账户。请确定您使用的Paypal账户是您用实名注册且您的Paypal邮件地址已经加入到您的交易账户记录。',
    'Webmoney': 'Webmoney是一种世界范围的电子钱包，提供了快速而简单的方式让您可以将资金存入Fxpro账户。',
    'golden_bank_transfer': '入金 ',
    'golden_bank_online':'在线支付',
    'golden_bank_card': '入金 信用卡/借记卡',
    'golden_status': '入金失败',
    'paytypecannot': '此支付方式尚未开通',
    'paytypecannotinto': '<div style=\'font-size:20px \'>Bank Infomation:</div><div style=\'text-align:center;font-size:12px\'><br/> FINANCIAL  SOLUTIONS  LIMITED<br/>ASB Bank New Zealand<br/>12-3232 - 0293459-00<br/>ASBBNZ2A<br/>ASB North Wharf, 12 Jellicoe Street, Auckland Central, Auckland 1010.<br/><br/><br/>* </div>',



    'banking_details': '电汇银行信息详情',
    'banking_details1': 'BENEFICIARY BANK NAME :',
    'banking_details11': '&nbsp;',

    'banking_details2': 'BANK ADDRESS :',
    'banking_details21': '&nbsp;',

    'banking_details3': 'BENEFICIARY ACCOUNT NAME :',
    'banking_details31': '&nbsp;',

    'banking_details4': 'SWIFT/BIC :',
    'banking_details41': '&nbsp;',

    'banking_details5': 'ACCOUNT NUMBER :',
    'banking_details51': '&nbsp;',



    'important_itemsb1': '',
    'important_itemsb2': '',




    'important_itemsa': '重要事项:',
    'important_itemsa1': '我们会把您转账的净额数值注入到您的钱包。净额数值是您转账最初金额减去银行间的手续费。',
    'important_itemsa2': '我们不收取任何电汇手续费。单笔最低数额是100美元或其他货币等值金额。',
    'important_itemsa3': '我们不接受现金至银行汇款方式，请您使用您的银行账户进行入金操作，我们不接收第三方入金。',
    'important_itemsa4': '电汇完成后请您保留好您的汇款单并扫描发送至 xxx@163.com 的方式及时告知我们。',
    'important_itemsa5': '这会缩短您的电汇入金处理时间，并以最准确快速的方式入账到您在我们的账户中。',
    'important_itemsa6': '通常电汇入金需要3-7个工作日，请您耐心等待。',






    'Telegraphictransfer':'电汇',
    //网银入金2
    'bank_transfer': '网银转账',
    'westfield_bank': '银行',
    'amount_gold': '入金金额',
    'wallet_bag': '钱包',
    'chouse_bank':'选择银行',
    'amount_gold1': '入金金额($)',

    'Confirm_request': '确认发送请求',

    'important_items1': '我们会把您在线入金的净额数值注入到您的钱包。净额数值是您转账最初金额。',
    'important_items2': '我们不收取任何入金手续费。单笔最低数额是100美元,最高数额是7000美元。',
    'important_items3': '请您使用您的银行账户进行入金操作，我们不接收第三方入金。',
    'btn_4': '此币种汇率暂无，请重新选择',
    'btn_1': '输入金额不符合规范',
    'btn_2': '数据接入错误',
    'btn_3': '不支持该货币',
    //网银入金3
    'bank_limit': '银行限额',
    'this_page': '如果入金是人民币 才出现这个页面',
    'cc_limit': '中国建设银行支付限额',
    'credit': '信用卡',
    'quasi': '准贷记卡和借记卡',
    'dynamic_password': '动态口令用户和和U盾用户（签约客户）',
    'message_password': '动态口令用户和短信口令卡',
    'single_limit': '单笔限额',
    'daily_limit': '每日限额',
    'USBkey': '便捷支付：登录建设银行网站，到网点柜面开户时预留手机号码自助申请开通，通过“网银客户支付”凭借收到的手机动态验证进行网上支付。借记卡高级客户需申请USBkey',
    'deposit_amount': '存款金额:',
    'amount_payable': '应付金额:',
    'confirm_payment': '确认付款',


    //入金完毕跳转到-管理资金页面
    'withdraw_money': '取款',
    'FxPro_Vauit ': 'FxPro Vauit电子钱包',
    'accepte': '已接受',
    'westfield_walletusd': '钱包 USD',
    //网银出金前页面
    'amount_money': '出金金额',
    'amount_money1': '出金金额($)',
    'fill_amount': '填写金额',
    'note': '请注意：您出金的银行账户名称必须是您本人。',
    'note1': '单日最高出金额度为100万人民币，超过此限制的金额将在下一个工作日进行处理',
    'note2': '如需要更改您的银行账户信息，请先在个人信息绑定银行卡一项里先操作，之后再出金',
    'payee_name': '收款人姓名',
    'bank_name': '银行名称',
    'bank_address':'银行地址',
    'bank_branch': '开户支行',
    'payee_ID': '收款人身份证号',
    're_phone': '收款人电话号码',
    'auto_display': '自动显示',
    'request': '确认发送请求',
    'ch_record': '查看出金记录',
    'taketype':'出金方式',
    //出金记录
    'gold_record': '出金记录',
    'application_time': '申请时间',
    'cash_withdrawal': '提现金额',
    'curr_withdrawal': '提现币种',
    'collection_information': '收款信息',
    'pending_treatment': '未处理',
    'al_played': '已打款',
    'fail': '失败：卡号错误',
    'alreadyprocessed': '已处理',
    'processingfailure':'处理失败',
    //代理专区
    'agentarea':'代理专区',
    'link': '我的代理链接',
    'rep_link': '复制代理链接',
    'two-dimensional': '生成二维码',
    'offline_account': '下线账户',
    'commission_transfer': '佣金结算',
    'URL_automatic': '网址自动获取生成',
    'account_number': '账号',
    'transaction_account': '交易账号',
    'account_properties': '账号类型',
    'transaction_number': '交易笔数',
    'settle_time': '结算时间',
    'timesSelect':'交易量查询',
    'allTradeTimes':'总交易量:',
    'allBonus':'总佣金:',
    'balance': '余额',
    'professional_account': '专业账户',
    'copy': '已复制',
    'confirm_settle': '确认结算？',
    'nobonus': '您暂无佣金可以结算~',
    'belong_user': '所属用户',
    'sure_settle': '<div style=\'text-align:center;padding-top:30px\'>佣金数据在同步中，如您急需结算佣金，请联系客服。</div>',
    'proxy_user': '代理用户',
    'personal_user': '个人用户',
    'hands': '手',
    'times': '笔',
    'checktradetime': '交易量查询',
    'checkcommission':'未结算佣金查看',
    //佣金转钱包
    'outstanding_Commission': '未结算佣金',
    'settlement_Commission': '结算佣金',
    'order': '订单',

    'subordinate_account': '所属账户',
    'transaction_type': '交易类型',

    'time': '时间',
    'return_amount': '返佣金额',






    //银行账户页面
    'bank_info': '银行卡资料',
    'card_type': '<span style="color: #dc143c;font-size:18px">*</span> 银行卡类型',
    'bank_type': '<span style="color: #dc143c;font-size:18px">*</span> 开户银行名称',
    'bank_branc': '<span style="color: #dc143c;font-size:18px">*</span> 开户行支行',
    'card_no': '<span style="color: #dc143c;font-size:18px">*</span> 银行卡号',
    'bank_address': '银行地址',
    'card_type1': ' 银行卡类型',
    'bank_type1': ' 开户银行名称',
    'bank_branc1': ' 开户行支行',
    'card_no1': ' 银行卡号',
    'bank_address1': '银行地址',


    //MT4账户提取
    'Mt4Tradingaccount': '已有MT4账户号:',
    'NewEmailAddress': '新Email地址',
    'MakeSureEmailAddress': '确认新Email地址',
    'extract': '提取',
    'close': '关闭',
    'mt4_extract': 'MT4账户提取',
     
    //老客户无邮箱
    'noemail': '未提交过邮箱客户',
    'Mt4pwd': 'MT4账户交易密码:',
    'EmailAddress': 'Email地址',
    'MakeSureEmailAddresss': '确认Email地址',
    'makesure': '确认',
    'getemailconfirm': '确定绑定此邮箱？',
    'moneyTakeTitle': '出金申请表'

}