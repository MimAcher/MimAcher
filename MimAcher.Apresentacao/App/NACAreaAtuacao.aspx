﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="NacAreaAtuacao.aspx.cs" MasterPageFile="~/Site.Master" Inherits="MimAcher.Apresentacao.App.NacAreaAtuacao" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="main">
   
<%-- Window --%>
	<ext:Window ID="NacAreaAtuacaoWindowId" Width="600" Height="220" Modal="true" runat="server" Hidden="true">
		<Items>

		<%-- Form --%>
		<ext:FormPanel ID="NacAreaAtuacaoFormPanelId" runat="server" Title="Inserir/Editar relação de Nac e Área de Atuação" BodyPadding="5" ButtonAlign="Right" Layout="Column">    
							   
			<FieldDefaults LabelAlign="Left" MsgTarget="Side" Size="100"  AllowBlank="false" />
														
			<Items> 
			
				<ext:FieldSet ID="NacAreaAtuacaoFieldSetId" runat="server" Title="Nac de Área de Atuação" MarginSpec="0 0 0 10">                                                      
					<Defaults>
						<ext:Parameter Name="AllowBlank" Value="true" Mode="Raw" />
						<ext:Parameter Name="MsgTarget" Value="side" />                                
					</Defaults>
					<Items>

						<%-- Código da relação de Nac e Área de Atuação --%>
						<ext:TextField ID="cod_nac_area_atuacaoId" Name="cod_nac_area_atuacao" runat="server" FieldLabel="Código" ReadOnly="true" />


						<%-- Combobox da Área de Atuação --%>
						<ext:ComboBox ID="cod_area_atuacaoId" Width="300" Name="cod_area_atuacao" AllowBlank="false" runat="server" FieldLabel="Nome da Área de Atuação" ValueField="cod_area_atuacao_combo" DisplayField="nome_combo">
							<Store>
								<ext:Store ID="StoreAreaAtuacaoId" runat="server">
									<Model>
										<ext:Model ID="ModelAreaAtuacaoId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_area_atuacao_combo" Mapping="cod_area_atuacao" />
												<ext:ModelField Name="nome_combo" Mapping="nome" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   

						<%-- Combobox de Nac --%>
						<ext:ComboBox ID="cod_nacId" Width="300" Name="cod_nac" AllowBlank="false" runat="server" FieldLabel="Representante" ValueField="cod_nac_combo" DisplayField="nome_representante_combo">
							<Store>
								<ext:Store ID="StoreNacId" runat="server">
									<Model>
										<ext:Model ID="ModelNacId" runat="server">
											<Fields>
												<ext:ModelField Name="cod_nac_combo" Mapping="cod_nac" />
												<ext:ModelField Name="nome_representante_combo" Mapping="nome_representante" />
											</Fields>
										</ext:Model>
									</Model>
								</ext:Store>
							</Store>
						</ext:ComboBox>   
						
					</Items>
				</ext:FieldSet>
			</Items>

			<BottomBar>
				<ext:StatusBar ID="NacAreaAtuacaoBarId" runat="server" />
			</BottomBar>

			<%-- Botões do Form --%>
			<Buttons>
				<ext:Button ID="SaveButtonId" runat="server" Text="Save" Disabled="false" FormBind="true" OnDirectClick="Save" />
				<ext:Button ID="CancelButtonId" runat="server" Text="Cancel" OnClientClick="#{NacAreaAtuacaoWindowId}.hide()"/>
			</Buttons>

			</ext:FormPanel>
		</Items>   
	</ext:Window>
	
 <%-- Grid --%> 
 <ext:GridPanel 
		ID="NacAreaAtuacaoGridPanelId"
		runat="server" 
		Title="Gerenciamento de Nac e Área de Atuação">         
		<%--Height="1500"--%>    

		 <Store>
			<ext:Store 
				ID="StoreNacAreaAtuacaoId" 
				runat="server" 
				PageSize="31" 
				OnReadData="List" 
				RemoteSort="true" 
				AutoLoad="true">
				<Model>
					<ext:Model ID="ModelNacAreaAtuacaoId" runat="server" IDProperty="cod_nac_area_atuacao">
						<Fields>
							<ext:ModelField Name="cod_nac_area_atuacao" Type="Int" />												
							<ext:ModelField Name="cod_area_atuacao"  Type="Int" />
							<ext:ModelField Name="nome" ServerMapping="MA_AREA_ATUACAO.nome" />                                                                                
							<ext:ModelField Name="cod_nac" Type="Int" />
							<ext:ModelField Name="nome_representante" ServerMapping="MA_Nac.nome_representante" />                                                                                
						</Fields>
					</ext:Model>
				</Model>
			</ext:Store>
		</Store>

		<%-- Colunas da Grid --%>
		<ColumnModel>
			<Columns>
				<ext:Column ID="codNacAreaAtuacaoColumnId" runat="server" Text="Código" DataIndex="cod_nac_area_atuacao" Visible="false" />
				<ext:Column ID="nomeAreaAtuacaoColumnId" runat="server" Text="Área de Atuação" Flex="2" DataIndex="nome" />                                  
				<ext:Column ID="nomeRepresentanteColumnId" runat="server" Text="Nome Representante do Nac" Flex="2" DataIndex="nome_representante" />                                  								
			</Columns>            
		</ColumnModel>    
		   
		<SelectionModel>
			<ext:RowSelectionModel ID="NacAreaAtuacaoRowSelectionModelId" Mode="Single" runat="server" >
					<Listeners>                        
						<Select Handler="#{NacAreaAtuacaoFormPanelId}.getForm().loadRecord(record); 
										 #{EditButtonId}.setDisabled(false);
										 #{DeleteButtonId}.setDisabled(false);" />                      
					</Listeners>                    
			</ext:RowSelectionModel>                        
		</SelectionModel>  

		<%-- Botões da Grid --%>
		<TopBar>
			<ext:Toolbar ID="ToolbarId" runat="server">
				<Items>
					<%-- Incluir --%>
					<ext:Button ID="IncluirButtonId" runat="server" Text="Novo Registro" Icon="PageAdd" OnClientClick="#{NacAreaAtuacaoWindowId}.show();#{NacAreaAtuacaoFormPanelId}.getForm().reset();" />

					<%-- Edit --%>
					<ext:Button ID="EditButtonId" runat="server" Text="Editar" Icon="PageEdit" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Edit">
								<ExtraParams>
									<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NacAreaAtuacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac_area_atuacao" />                                
								</ExtraParams>
							</Click>
						</DirectEvents>
					</ext:Button>

					<%-- Delete --%>
					<ext:Button ID="DeleteButtonId" runat="server" Text="Excluir Registro" Icon="Delete" Disabled="true" >
						<DirectEvents>
							<Click OnEvent="Delete">
								<Confirmation ConfirmRequest="true" Message="Deseja excluir este registro?" />                                
							</Click>
						</DirectEvents>
					</ext:Button>

					<%-- Atualizar --%>
					<ext:Button ID="AtualizarButtonId" runat="server" Text="Atualizar" Icon="Reload" OnDirectClick="List" /> 
				</Items>
			</ext:Toolbar>
		</TopBar>

		<%-- Double Click --%>
		<DirectEvents>
			<ItemDblClick OnEvent="Edit">
				<ExtraParams>                    
					<ext:Parameter Name="RecordGrid" Mode="Raw" Value="#{NacAreaAtuacaoGridPanelId}.getRowsValues({selectedOnly : true})[0].cod_nac_area_atuacao" />                                
				</ExtraParams>
			</ItemDblClick>
		</DirectEvents>

		<BottomBar>
			<ext:PagingToolbar ID="PagingToolbarId" runat="server" />
		</BottomBar>

	</ext:GridPanel>

</asp:Content>
