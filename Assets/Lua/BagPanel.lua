-- 改用面向对象 让MainPanel继承父类BasePanel
BasePanel:subClass("BagPanel")
BagPanel.Content = nil
--用来存储当前 显示的格子
BagPanel.items = {}
BagPanel.nowType = -1

function BagPanel:Init(name)
    self.base.Init(self, name)

    if self.isInitEvent == false then
        -- 获取Content
        self.Content = self:GetControl("svBag", "ScrollRect").transform:Find("Viewport"):Find("Content")
        -- 关闭按钮
        self:GetControl("btnClose", "Button").onClick:AddListener(function()
            self:HideMe()
            -- 关闭鼠标
            CS.GameUI.Instance:CloseMouse()
        end)
        -- 为 toggle 添加事件
        self:GetControl("togPlayer", "Toggle").onValueChanged:AddListener(function(value)
            if value == true then
                self:ChangeType(1)
            end
        end)
        self:GetControl("togItem", "Toggle").onValueChanged:AddListener(function(value)
            if value == true then
                self:ChangeType(2)
            end
        end)

        self.isInitEvent = true
    end
end

-- 重写父类显示方法
function BagPanel:ShowMe(name) 
    self.base.ShowMe(self, name) -- 先调用父类的初始化方法
    self.panelObj:SetActive(true)
    if self.nowType == -1 then
        self:ChangeType(1)
    else
        self:ChangeType(self.nowType)
    end
end

function BagPanel:ChangeType(type)
    self.nowType = type

    --删除格子
    for i = 1, #self.items do
        self.items[i]:Destroy()
    end
    self.items = {}--列表清空

    if type == 1 then
        local param = PlayerParam:new()
        param:Init(self.Content)
        table.insert(self.items, param)
    else
        local i = 0;
        for k, v in pairs(GameData.bagItems) do
            local grid = ItemGrid:new()
            grid:Init(self.Content, (i)%4*137.5, math.floor((i)/4) * -137.5)
            grid:InitData({id = k, num = v})
            --存起来
            table.insert(self.items, grid)
            i = i + 1
        end
    end
end