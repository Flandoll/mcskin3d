﻿#if CONVERT_MODELS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static MCSkin3D.ModelLoader;

namespace MCSkin3D.Models.Convert
{
	public class ModelBat : ModelBase
	{
		private ModelRenderer batHead;

		/** The body box of the bat model. */
		private ModelRenderer batBody;

		/** The inner right wing box of the bat model. */
		private ModelRenderer batRightWing;

		/** The inner left wing box of the bat model. */
		private ModelRenderer batLeftWing;

		/** The outer right wing box of the bat model. */
		private ModelRenderer batOuterRightWing;

		/** The outer left wing box of the bat model. */
		private ModelRenderer batOuterLeftWing;

		public ModelBat()
		{
			this.textureWidth = 64;
			this.textureHeight = 64;
			this.batHead = new ModelRenderer(this, 0, 0, ModelPart.Head);
			this.batHead.addBox(-3.0F, -3.0F, -3.0F, 6, 6, 6, "Head");
			ModelRenderer modelrenderer = new ModelRenderer(this, 24, 0, ModelPart.Head);
			modelrenderer.addBox(-4.0F, -6.0F, -2.0F, 3, 4, 1, "Right Ear");
			this.batHead.addChild(modelrenderer);
			ModelRenderer modelrenderer1 = new ModelRenderer(this, 24, 0, ModelPart.Head);
			modelrenderer1.mirror = true;
			modelrenderer1.addBox(1.0F, -6.0F, -2.0F, 3, 4, 1, "Left Ear");
			this.batHead.addChild(modelrenderer1);
			this.batBody = new ModelRenderer(this, 0, 16, ModelPart.Chest);
			this.batBody.addBox(-3.0F, 4.0F, -3.0F, 6, 12, 6, "Body");
			this.batBody.setTextureOffset(0, 34).addBox(-5.0F, 16.0F, 0.0F, 10, 6, 1, "Feet");
			this.batRightWing = new ModelRenderer(this, 42, 0, ModelPart.RightArm);
			this.batRightWing.addBox(-12.0F, 1.0F, 1.5F, 10, 16, 1, "Right Wing");
			this.batOuterRightWing = new ModelRenderer(this, 24, 16, ModelPart.RightArm);
			this.batOuterRightWing.setRotationPoint(-12.0F, 1.0F, 1.5F);
			this.batOuterRightWing.addBox(-8.0F, 1.0F, 0.0F, 8, 12, 1, "Right Outer Wing");
			this.batLeftWing = new ModelRenderer(this, 42, 0, ModelPart.LeftArm);
			this.batLeftWing.mirror = true;
			this.batLeftWing.addBox(2.0F, 1.0F, 1.5F, 10, 16, 1, "Left Wing");
			this.batOuterLeftWing = new ModelRenderer(this, 24, 16, ModelPart.LeftArm);
			this.batOuterLeftWing.mirror = true;
			this.batOuterLeftWing.setRotationPoint(12.0F, 1.0F, 1.5F);
			this.batOuterLeftWing.addBox(0.0F, 1.0F, 0.0F, 8, 12, 1, "Left Outer Wing");
			this.batBody.addChild(this.batRightWing);
			this.batBody.addChild(this.batLeftWing);
			this.batRightWing.addChild(this.batOuterRightWing);
			this.batLeftWing.addChild(this.batOuterLeftWing);
		}

#if RENDER
		/**
		 * Sets the models various rotation angles then renders the model.
		 */
		public void render(Entity entityIn, float p_78088_2_, float p_78088_3_, float p_78088_4_, float p_78088_5_, float p_78088_6_, float scale)
		{
			this.setRotationAngles(p_78088_2_, p_78088_3_, p_78088_4_, p_78088_5_, p_78088_6_, scale, entityIn);
			this.batHead.render(scale);
			this.batBody.render(scale);
		}
#endif

		/**
		 * Sets the model's various rotation angles. For bipeds, par1 and par2 are used for animating the movement of arms
		 * and legs, where par1 represents the time(so that arms and legs swing back and forth) and par2 represents how
		 * "far" arms and legs can swing at most.
		 */
		public void setRotationAngles(float limbSwing, float limbSwingAmount, float ageInTicks, float netHeadYaw, float headPitch, float scaleFactor, Entity entityIn)
		{
			if (((EntityBat)entityIn).getIsBatHanging())
			{
				this.batHead.rotateAngleX = headPitch * 0.017453292F;
				this.batHead.rotateAngleY = (float)Math.PI - netHeadYaw * 0.017453292F;
				this.batHead.rotateAngleZ = (float)Math.PI;
				this.batHead.setRotationPoint(0.0F, -2.0F, 0.0F);
				this.batRightWing.setRotationPoint(-3.0F, 0.0F, 3.0F);
				this.batLeftWing.setRotationPoint(3.0F, 0.0F, 3.0F);
				this.batBody.rotateAngleX = (float)Math.PI;
				this.batRightWing.rotateAngleX = -0.15707964F;
				this.batRightWing.rotateAngleY = -((float)Math.PI * 2F / 5F);
				this.batOuterRightWing.rotateAngleY = -1.7278761F;
				this.batLeftWing.rotateAngleX = this.batRightWing.rotateAngleX;
				this.batLeftWing.rotateAngleY = -this.batRightWing.rotateAngleY;
				this.batOuterLeftWing.rotateAngleY = -this.batOuterRightWing.rotateAngleY;
			}
			else
			{
				this.batHead.rotateAngleX = headPitch * 0.017453292F;
				this.batHead.rotateAngleY = netHeadYaw * 0.017453292F;
				this.batHead.rotateAngleZ = 0.0F;
				this.batHead.setRotationPoint(0.0F, 0.0F, 0.0F);
				this.batRightWing.setRotationPoint(0.0F, 0.0F, 0.0F);
				this.batLeftWing.setRotationPoint(0.0F, 0.0F, 0.0F);
				this.batBody.rotateAngleX = ((float)Math.PI / 4F) + MathHelper.cos(ageInTicks * 0.1F) * 0.15F;
				this.batBody.rotateAngleY = 0.0F;
				this.batRightWing.rotateAngleY = MathHelper.cos(ageInTicks * 1.3F) * (float)Math.PI * 0.25F;
				this.batLeftWing.rotateAngleY = -this.batRightWing.rotateAngleY;
				this.batOuterRightWing.rotateAngleY = this.batRightWing.rotateAngleY * 0.5F;
				this.batOuterLeftWing.rotateAngleY = -this.batRightWing.rotateAngleY * 0.5F;
			}
		}
	}
}
#endif