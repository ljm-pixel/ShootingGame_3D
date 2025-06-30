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
        end)
        -- 为 toggle 添加事件
        self:GetControl("togEquip", "Toggle").onValueChanged:AddListener(function(value)
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
    end
end

function BagPanel:ChangeType(type)
    if self.nowType == type then
        return
    else
        self.nowType = type
    end

    --删除格子
    for i = 1, #self.items do
        self.items[i]:Destroy()
    end
    self.items = {}--列表清空

    local nowItems = nil
    if type == 1 then
        nowItems = PlayerData.equips
    elseif type == 2 then
        nowItems = PlayerData.items
    else
        nowItems = PlayerData.gems
    end

    for i = 1, #nowItems do
        local grid = ItemGrid:new()
        grid:Init(self.Content, (i-1)%4*120, math.floor((i-1)/4) * -120)
        grid:InitData(nowItems[i])
        --存起来
        table.insert(self.items, grid)
    end

end